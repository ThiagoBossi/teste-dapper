using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TesteDapper.Fonte.DAL;
using TesteDapper.Fonte.DTO;
using TesteDapper.Fonte.DTO.Teste;
using TesteDapper.Formularios;

namespace TesteDapper
{
    public partial class frmInicial : Form
    {
        #region Construtor do Formulário
        public frmInicial()
        {
            InitializeComponent();
            dalConexao.realizarConexao();
        }
        #endregion

        #region Eventos do Formulário
        private void btnBuscarDados_Click(object sender, EventArgs e)
        {
            var query = @"
                SELECT e.EmployeeId, e.FullName, e.AdmissionDate, d.DepartmentId, d.DepartmentName, do.DoorId DoorId, do.DoorName DoorName 
                FROM Employees e 
	            INNER JOIN EmployeeDepartment ed ON ed.EmployeeId = e.EmployeeId 
	            INNER JOIN Departments d ON ed.DepartmentId = d.DepartmentId 
	            INNER JOIN DepartmentDoor dd ON dd.DepartmentId = d.DepartmentId
	            INNER JOIN Doors do ON dd.DoorId = do.DoorId"
            ;

            var employeeDictionary = new Dictionary<int, Employee>();

            var resultado = dalConexao.conexao.Query<Employee, Department, Door, Employee>(
                query,
                (employee, department, door) =>
                {
                    if (!employeeDictionary.TryGetValue(employee.EmployeeId, out var existingEmployee))
                    {
                        existingEmployee = employee;
                        existingEmployee.Departments = new List<Department>();
                        employeeDictionary.Add(existingEmployee.EmployeeId, existingEmployee);
                    }

                    var existingDepartment = existingEmployee.Departments.FirstOrDefault(d => d.DepartmentId == department.DepartmentId);

                    if (existingDepartment == null)
                    {
                        department.Doors = department.Doors ?? new List<Door>();
                        department.Doors.Add(door);
                        existingEmployee.Departments.Add(department);
                    }
                    else
                    {
                        existingDepartment.Doors.Add(door);
                    }

                    return existingEmployee;
                },
                splitOn: "DepartmentId, DoorId"
            );

            var employeeList = employeeDictionary.Values.ToList();

            listaDados.DataSource = employeeList;
        }
        private void listaDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var employee = (Employee)listaDados.Rows[e.RowIndex].DataBoundItem;

                var frmExibirVendas = new frmExibirDados(employee.Departments);
                frmExibirVendas.ShowDialog();

                if (frmExibirVendas.DialogResult == DialogResult.OK)
                {
                    var department = (Department)frmExibirDados.objetoRetorno;

                    var frmExibirDetalhesVenda = new frmExibirDados(department.Doors);
                    frmExibirDetalhesVenda.ShowDialog();
                }
            }
        }
        #endregion

        #region Funções do Formulário
        private void codigoJoin()
        {
            var query = @"
                SELECT * FROM clientes c 
                INNER JOIN vendas v ON c.codigo = v.codigocliente 
                INNER JOIN detalhevendas dv ON v.numero = dv.numero"
            ;

            var dicionarioClientes = new Dictionary<int, dtoCliente>();

            var resultado = dalConexao.conexao.Query<dtoCliente, dtoVenda, dtoDetalheVenda, dtoCliente>(
                query,
                (cliente, venda, detalhe) =>
                {
                    dtoCliente clienteExistente;

                    if (!dicionarioClientes.TryGetValue(cliente.codigo, out clienteExistente))
                    {
                        clienteExistente = cliente;
                        clienteExistente.vendas = new List<dtoVenda>();
                        dicionarioClientes.Add(clienteExistente.codigo, clienteExistente);
                    }

                    if (clienteExistente.vendas == null)
                    {
                        clienteExistente.vendas = new List<dtoVenda>();
                    }

                    var vendaExistente = clienteExistente.vendas.FirstOrDefault(v => v.numero == venda.numero);

                    if (vendaExistente == null)
                    {
                        vendaExistente = venda;
                        vendaExistente.itens = new List<dtoDetalheVenda>();
                        clienteExistente.vendas.Add(vendaExistente);
                    }

                    vendaExistente.itens.Add(detalhe);

                    return clienteExistente;
                },
                splitOn: "numero, numero"
            );

            var clientes = dicionarioClientes.Values.ToList();

            listaDados.DataSource = clientes;
        }
        #endregion
    }
}
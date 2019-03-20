using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoGrupoPcSolucoes.Conexao;


class ClienteBO
{
    public String InserirCliente(cliente obj)
    {
        string result = Validar(obj);

        if (result == "")
        {
            ClienteDAO clinteDAO = new ClienteDAO();
            clinteDAO.InserirCliente(obj);

            return "Cliente Inserido com sucesso!";
        }
        else
        {
            return result;
        }


    }

    public String EditarCliente(cliente obj)
    {
        ClienteDAO clinteDAO = new ClienteDAO();
        clinteDAO.EditarCliente(obj);

        return "Cliente editado com sucesso!";

    }

    public String Deletar(int CodCliente)
    {
        ClienteDAO clinteDAO = new ClienteDAO();
        clinteDAO.Deletar(CodCliente);

        return "Cliente Deletado com sucesso!";

    }

    public IList<ResultCliente> ListarGridCliente()
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        IList<ResultCliente> listCliente = clienteDAO.ListarGridCliente();

        return listCliente;
    }

    public cliente BuscarClienteId(int Codcliente)
    {
        ClienteDAO clienteDAO = new ClienteDAO();

        cliente obj = clienteDAO.BuscarClienteId(Codcliente);

        return obj;
    }

    public IList<ResultCliente> Pesquisar(cliente obj)
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        IList<ResultCliente> listCliente = clienteDAO.Pesquisar(obj);
        return listCliente;
    }

    private String Validar(cliente Obj)
    {
        if (Obj.TipInscricao == "F")
        {
            if (Obj.Cpf == "")
            {
                return "Insira seu CPF!";
            }
            if (Obj.DtNacimento.ToString() == "")
            {
                return "Insira sua data de nacimento!";
            }
            if (Obj.NomFantasia == "")
            {
                return "Insira seu Nome!";
            }


        }
        else
        {
            if (Obj.Cnpj == "")
            {
                return "Insira seu CNPJ!";
            }
            if (Obj.DtAtividade.ToString() == "")
            {
                return "Insira sua data de de início de atividade!";
            }
            if (Obj.NomFantasia == "")
            {
                return "Insira sueu Nome!";
            }
            if (Obj.RazaoSocial == "")
            {
                return "Insira a razão social!";
            }

        }

        return "";
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoGrupoPcSolucoes.Conexao;

class ClienteDAO
{

    public void InserirCliente(cliente obj)
    {
        using (cadastroEntities ctx = new cadastroEntities())
        {
            ctx.cliente.Add(obj);
            ctx.SaveChanges();
        }
        
    }

    public void EditarCliente(cliente obj)
    {
        using (cadastroEntities ctx = new cadastroEntities())
        {
            var consulta = ctx.cliente;
            cliente objCiente = consulta.Find(obj.CodCliente);
            if (objCiente != null)
            {
                objCiente.Cep = obj.Cep;
                objCiente.Cnpj = obj.Cnpj;
                objCiente.Cpf = obj.Cpf;
                objCiente.DtAtividade = obj.DtAtividade;
                objCiente.DtNacimento = obj.DtNacimento;
                objCiente.Email = obj.Email;
                objCiente.Endereço = obj.Endereço;
                objCiente.NomFantasia = obj.NomFantasia;
                objCiente.Numero = obj.Numero;
                objCiente.RazaoSocial = obj.RazaoSocial;
                objCiente.TipInscricao = obj.TipInscricao;

                ctx.SaveChanges();
            }

        }

    }

    public IList<ResultCliente> ListarGridCliente()
    {
        List<ResultCliente> listCliente = new List<ResultCliente>();

        using (cadastroEntities ctx = new cadastroEntities())
        {
            var consulta = ctx.cliente;
            //listCliente = consulta.SqlQuery("select CodCliente,  NomFantasia, RazaoSocial, TipInscricao, DtNacimento, DtAtividade, Fone from Cliente  ORDER BY CodCliente DESC").ToList();
            /*istCliente = consulta.ToList();*/
            foreach(cliente item in consulta.ToList())
            {
                ResultCliente obj = new ResultCliente();
                obj.CodCliente = item.CodCliente;
                obj.NomFantasia = item.NomFantasia;
                obj.RazaoSocial = item.RazaoSocial;
                obj.TipInscricao = item.TipInscricao;
                obj.DtAtividade = item.DtAtividade;
                obj.DtNacimento = item.DtNacimento;
                obj.Fone = item.Fone;

                listCliente.Add(obj);

            }
        }
        return listCliente;
    }

    public cliente BuscarClienteId(int Codcliente)
    {
        List<cliente> listCliente = new List<cliente>();
        cliente obj = new cliente();
        using (cadastroEntities ctx = new cadastroEntities())
        {
            var consulta = ctx.cliente;
            //listCliente = consulta.SqlQuery("select CodCliente, NomFantasia, RazaoSocial, TipInscricao, Cpf, Cnpj, DtNacimento, DtAtividade, Endereço, Numero, Cep, Fone, Email from Cliente  where CodCliente = " + Codcliente).ToList();
            obj = consulta.Find(Codcliente);
        }
        return obj;
    }

    public void Deletar(int Codcliente)
    {
        cliente obj = new cliente();
        using (cadastroEntities ctx = new cadastroEntities())
        {
            var consulta = ctx.cliente;
            obj = consulta.Find(Codcliente);
            consulta.Remove(obj);
            ctx.SaveChanges();
        }
        
    }

    public IList<ResultCliente> Pesquisar(cliente objCliente)
    {
        List<ResultCliente> listResultCliente = new List<ResultCliente>();
        IList<cliente> listCliente;
        using (cadastroEntities ctx = new cadastroEntities())
        {
            var resultado = from sql in ctx.cliente
                            where sql.NomFantasia.Contains(objCliente.NomFantasia)
                            select sql;
            listCliente = resultado.ToList();
        }

        foreach (cliente item in listCliente)
        {
            ResultCliente obj = new ResultCliente();
            obj.CodCliente = item.CodCliente;
            obj.NomFantasia = item.NomFantasia;
            obj.RazaoSocial = item.RazaoSocial;
            obj.TipInscricao = item.TipInscricao;
            obj.DtAtividade = item.DtAtividade;
            obj.DtNacimento = item.DtNacimento;
            obj.Fone = item.Fone;

            listResultCliente.Add(obj);

        }

        return listResultCliente;
    }
}


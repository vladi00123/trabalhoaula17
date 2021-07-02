using System;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;

public class Produto 
{
  private int _id;
  private string _nome;
  private double _preco;

  public int Id
  {
    get {
      return _id;
    }
  }

  public string Nome
  {
    get {
      return _nome;
    }
  }

  public double Preco{
    get {
      return _preco;
    }
  }

  public Produto(string nome, double preco)
  {
    this._nome = nome;
    this._preco = preco;
  }//END METHOD

  public void Imprimir()
  {
    Console.WriteLine("======================");
    Console.WriteLine("ID:\t\t\t{0}", this._id);
    Console.WriteLine("Produto:\t{0}", this._nome);
    Console.WriteLine("Preço:\t\tR$ {0:0.00}\n", this._preco);
    Console.WriteLine("======================");
  }//END METHOD

  public void Persistir()
  {
    using (var connection = new SqliteConnection("Data Source=banco.db"))
    {
      connection.Open();

      var command = connection.CreateCommand();
      command.CommandText =
      @"
        INSERT INTO produto (nome, preco)
        VALUES ($nome, $preco);
      ";
      command.Parameters.AddWithValue("$nome", this._nome);
      command.Parameters.AddWithValue("$preco", this._preco);

      command.ExecuteNonQuery();
      Console.WriteLine("======================");
      Console.WriteLine("Adicionado com sucesso!");
      Console.WriteLine("Pressione qualquer tecla para sair!");
      Console.WriteLine("======================");
    }
  }//END METHOD







  public static List<Produto> ProcurarProdutos(string produto_)
  {
   
    List<Produto> produtos = new List<Produto>();

    using (var connection = new SqliteConnection("Data Source=banco.db"))
    {
      connection.Open();

      var command = connection.CreateCommand();
      command.CommandText =
      @"
        SELECT id, nome, preco
        FROM produto
        WHERE nome LIKE '%' || @item ||'%';
      ";     

      command.Parameters.AddWithValue("@item", produto_);
  
      using (var reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          var id = reader.GetInt32(0);
          var nome = reader.GetString(1);
          var preco = reader.GetDouble(2);

          Produto p = new Produto(nome, preco);
          p._id = id;

          produtos.Add(p);
        }
      }

    }

  return produtos;
  }//END METHOD


  public static List<Produto> ConsultarProdutos()
    {
      List<Produto> produtos = new List<Produto>();

      using (var connection = new SqliteConnection("Data Source=banco.db"))
      {
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
          SELECT id, nome, preco
          FROM produto;
        ";

        using (var reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            var id = reader.GetInt32(0);
            var nome = reader.GetString(1);
            var preco = reader.GetDouble(2);

            Produto p = new Produto(nome, preco);
            p._id = id;

            produtos.Add(p);
          }
        }

      }

      return produtos;
    }//END METHOD






  public static void Deletar()
 {
    using( var connection = new SqliteConnection("Data Source=banco.db"))
     {
      connection.Open();
      var command = connection.CreateCommand();
      command.CommandText =
      @"
       DELETE FROM produto;
      ";
      command.ExecuteNonQuery();
      Console.WriteLine("======================");
      Console.WriteLine("Deletados com sucesso!");
      Console.WriteLine("Pressione qualquer tecla para sair!");
      Console.WriteLine("======================");
     }
 }//END METHOD






 

}

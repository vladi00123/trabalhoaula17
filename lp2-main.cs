using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;


class MainClass {

   
  public static void Cadastrar(){
 
    Console.WriteLine("\n\nCadastro de Produto");
    Console.Write("título: ");
    string título = Console.ReadLine();
    Console.Write("custo: ");
    double custo = Convert.ToDouble(Console.ReadLine());
    Produto p = new Produto(título, custo);
    p.Persistir();

  }

  public static void Listar()
  {
    Console.WriteLine("\n");
    List<Produto> produtos = Produto.ConsultarProdutos();
    foreach(var produto in produtos)
    {
      produto.Imprimir();
    }
    Console.WriteLine("======================");
    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA VOLTAR");
    Console.WriteLine("======================");
  }


  public static void Procurar()
  {  
    Console.Clear();
    Console.WriteLine("======================");
    Console.WriteLine("Escreva o nome do produto de que deseja procurar");
    Console.WriteLine("======================");

    string procurar_ = Console.ReadLine();
 
    Console.Clear();
    Console.WriteLine("======================");
    Console.WriteLine("Mostrando todos os registros de: {0}", procurar_);
    Console.WriteLine("======================");
  
    List<Produto> produtos = Produto.ProcurarProdutos(procurar_);
    foreach(var produto in produtos)
    {
      produto.Imprimir();
    }
  
    Console.WriteLine("======================");
    Console.WriteLine("PRESSIONE QUALQUER TECLA PARA VOLTAR");
    Console.WriteLine("======================");
  }
 

 
    public static void Main(string[] args)
          {                 
                bool MostrarMenu = true;
                while (MostrarMenu)
                {
                    MostrarMenu = MenuPrincipal();
                }
          }




          private static bool MenuPrincipal()
            {

                Console.Clear();
                Console.WriteLine("==================================================================");
                Console.WriteLine("Entre com '1' para Listar os produtos");
                Console.WriteLine("Entre com '2' para Cadastrar um produto");
                Console.WriteLine("Entre com '3' para Deletar todos os produtos");
                Console.WriteLine("Entre com '4' para Pesquisar um produto");
                Console.WriteLine("Entre com '5' para Fechar a aplicação");
                Console.WriteLine("==================================================================");
                switch (Console.ReadLine())
                {
                        
                        case "1":
                            Listar();
                            Console.Read();    
                         return true;

                        case "2":
                            Cadastrar();
                            Console.Read();                          
                        return true;

                        case "3":
                            Produto.Deletar();
                            Console.Read();                          
                        return true;

                        case "4":                       
                            Procurar();
                            Console.Read();   
                        return true;


                        //Close Program
                        case "5":
                           Console.Clear();
                           Console.WriteLine("======================");
                           Console.WriteLine("Finalizado com sucesso!");
                           Console.WriteLine("Obrigado por utilizar o sistema!");
                           Console.WriteLine("======================");
                           return false;
                           

                        //DEFAULT ROUTE (BACK TO MENU)
                        default:
                            return true;



                }//END SWITCH




            }//END METHOD


}

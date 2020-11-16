using System;
using System.IO;
using Newtonsoft.Json;
using Google.Cloud.Firestore;
using Experimental.System.Messaging;

namespace Agente2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------------------------\n");
            Console.WriteLine("                              Agente 2                                 \n");

            Console.WriteLine("Deseas imprimir la cola?\n S. Si \n N. No");
            string r=Console.ReadLine();
        

            while (r != "N")
            {
     
             Console.WriteLine("Imprimiendo Cola.......\n");
             //Creación de la conexión con la cola 
             MessageQueue servidor = new MessageQueue(".\\Private$\\Nombres");

             //pop
             Message messajeJson=servidor.Receive();
             messajeJson.Formatter= new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
             Console.WriteLine(messajeJson.Body);
            
          
             //Conexión al archivo de texto
             TextWriter escribir = new StreamWriter(@"C:\Users\Jazmi\Downloads\Cola.txt");
             escribir.WriteLine(messajeJson.Body);
             escribir.Close();
             
            }

        }
    }
    public class Messagenom
    {
       public string Nombre {get; set;}
    }

}

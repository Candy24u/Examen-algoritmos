using System;
using System.IO;
using Newtonsoft.Json;
using Experimental.System.Messaging;

namespace Agente_1
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("----------------------------------------------------------------------\n");
            Console.WriteLine("                              Agente 1                                 \n");
        
            Console.WriteLine("Deseas enviar nombres aleatorios a la cola?\n S. Si \n N. No");
            string ne=Console.ReadLine();

            while (ne != "N")
            {
               //Mensaje
             string result = Path.GetRandomFileName();
        

             //Creación de la conexión con la cola 
             MessageQueue servidor = new MessageQueue(".\\Private$\\Nombres");
             //int iCount = Queue.GetAllMessages().count();

             //Convertir el mensaje
             String jsonMessage=JsonConvert.SerializeObject(result);

             //Empaquetar el mensaje
             //Message msg = new Message();
             // msg.Body=jsonMessage;

             //Enviar mensaje
             Console.WriteLine("Nombre aleatorio enviado");
             Console.WriteLine(result);
             servidor.Send(result);
        
            }
        
        }

    }
    public class Messagenom
    {
       public string Nombre {get; set;}
    }


}


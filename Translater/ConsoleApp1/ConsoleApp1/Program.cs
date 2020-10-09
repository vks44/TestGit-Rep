using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your US-EN input text >> "); 
            string input = Console.ReadLine();
            TransBride(input);// What is your Name.");
        }


        public static void TransBride(string textvalue)
        {
            //Subscription ID= 0fe22794 - 6493 - 41d6 - 8c43 - 2417365b43c6//"54150bc0d08b4f8ca6168f756d2a6750";//
            string appId =  "A70C584051881A30549986E65FF4B92B95B353A5"; //go to http://msdn.microsoft.com/en-us/library/ff512386.aspx to obtain AppId.
                                                                      // string textvalue = "Translate this for me";
            string from = "en";
            string to = "es";
            string uri = "http://api.microsofttranslator.com/v2/Http.svc/Translate?appId=" + appId + "&text=" + textvalue + "&from=" + from + "&to=" + to;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            WebResponse response = null;
            try
            {
                response = httpWebRequest.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    DataContractSerializer dcs = new DataContractSerializer(Type.GetType("System.String"));
                    string translation = (string)dcs.ReadObject(stream);

                    Console.Write("Spanish translations of your input is >>");
                    Console.WriteLine(translation);
                    Console.Read();
                  
                }
            }
            catch (WebException e)
            {
                //test cumment 
                //test cumment 
               // ProcessWebException(e, "Failed to translate");
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                    response = null;
                }
            }
        }

        public static void  GetData()
        {
            Console.WriteLine("hello"); 
        }
       
    }
}

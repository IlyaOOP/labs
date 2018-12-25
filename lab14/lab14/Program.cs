using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace lab14_XAMARIN
{
    
    [System.Serializable]
    public class куст
    {
        public int length;
        public double prevalence { get; set; }
        public double condition { get; set; }
        public куст(int len, double preval, double cond)
        {
            length = len;
            prevalence = preval;
            condition = cond;
        }
        public куст()
        {
            length = 0;
            prevalence = 0;
            condition = 0;
        }
        public override string ToString()
        {
            return (this.GetType() + "\nвысота: " + length + "\nраспространенность: " + prevalence);
        }
        public void print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(this.GetType());
            Console.ResetColor();
            Console.WriteLine("высота: " + length + "\nраспространенность: " + prevalence);
            Console.ResetColor();
        }
    }

    public static class serializer
    {
        public static void binarySerialization(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, obj);
                Console.WriteLine("binary serialisation");
            }
        }
        public static void binaryDeserealisation(bool flag)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("binary.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine("binary deserialisation");
                if (flag == true)
                {
                    var objec = bf.Deserialize(fs);
                    куст kbin;
                    kbin = (куст)objec;
                    Console.WriteLine("object: ");
                    kbin.print();
                    Console.WriteLine("____________________");
                }
                else
                {
                    object[] objec = (object[])bf.Deserialize(fs);
                    Console.WriteLine("object: ");
                    foreach (куст k in objec)
                    {
                        k.print();
                    }
                    Console.WriteLine("____________________");
                }
            }
        }

        public static void SOAPSerialization(object obj)
        {
            SoapFormatter sf = new SoapFormatter();

            using (FileStream fs = new FileStream("soap.soap", FileMode.OpenOrCreate))
            {
                sf.Serialize(fs, obj);

                Console.WriteLine("SOAP serialisation");
            }
        }
        public static void SOAPdeserialisation(bool flag)
        {
            SoapFormatter sf = new SoapFormatter();

            using (FileStream fs = new FileStream("soap.soap", FileMode.OpenOrCreate))
            {
                Console.WriteLine("soap deserialisation");
                if (flag == true)
                {
                    var objec = sf.Deserialize(fs);
                    куст kbin;
                    kbin = (куст)objec;
                    Console.WriteLine("object: ");
                    kbin.print();
                    Console.WriteLine("____________________");
                }
                else
                {
                    object[] objec = (object[])sf.Deserialize(fs);
                    Console.WriteLine("object: ");
                    foreach (куст k in objec)
                    {
                        k.print();
                    }
                    Console.WriteLine("____________________");
                }
            }
        }

        public static void JSONserialisation(object obj)
        {
            DataContractJsonSerializer jf = new DataContractJsonSerializer(obj.GetType());

            using (FileStream fs = new FileStream("json.json", FileMode.OpenOrCreate))
            {
                jf.WriteObject(fs, obj);
                Console.WriteLine("JSON serialisation");

            }
        }
        public static void JSONdeserialisation(object obj, bool flag)
        {
            DataContractJsonSerializer jf = new DataContractJsonSerializer(obj.GetType());

            using (FileStream fs = new FileStream("json.json", FileMode.OpenOrCreate))
            {
                Console.WriteLine("json deserialisation");
                if (flag == true)
                {
                    var objec = jf.ReadObject(fs);
                    куст kbin;
                    kbin = (куст)objec;
                    Console.WriteLine("object: ");
                    kbin.print();
                    Console.WriteLine("____________________");
                }
                else
                {
                    object[] objec = (object[])jf.ReadObject(fs);
                    Console.WriteLine("object: ");
                    foreach (куст k in objec)
                    {
                        k.print();
                    }
                    Console.WriteLine("____________________");
                }
            }
        }

        public static void XMLserialisation(object obj)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());

            using (FileStream fs = new FileStream("xml.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, obj);
                Console.WriteLine("XML serialisation");
            }
        }
        public static void XMLdeserialisation(object obj, bool flag)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType());

            using (FileStream fs = new FileStream("xml.xml", FileMode.OpenOrCreate))
            {
                if (flag == true)
                {
                    var objec = xs.Deserialize(fs);
                    куст kbin;
                    kbin = (куст)objec;
                    Console.WriteLine("object: ");
                    kbin.print();
                    Console.WriteLine("____________________");
                }
                else
                {
                    object[] objec = (object[])xs.Deserialize(fs);
                    Console.WriteLine("object: ");
                    foreach (куст k in objec)
                    {
                        k.print();
                    }
                    Console.WriteLine("____________________");
                }
            }
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            куст bin = new куст(1,0.5,0.5);
            куст soap = new куст(2, 0.5, 0.5);
            куст json = new куст(3, 0.5, 0.5);
            куст xml = new куст(4, 0.5, 0.5);

            serializer.binarySerialization(bin);
            serializer.binaryDeserealisation(true);

            serializer.SOAPSerialization(soap);
            serializer.SOAPdeserialisation(true);

            serializer.JSONserialisation(json);
            serializer.JSONdeserialisation(json, true);

            serializer.XMLserialisation(xml);
            serializer.XMLdeserialisation(xml, true);

            //t2
            object[] ob =
            {
                bin, soap, json, xml
            };

            Console.WriteLine("_____________________________________________________________________");

            serializer.binarySerialization(ob);
            serializer.binaryDeserealisation(false);

            serializer.SOAPSerialization(ob);
            serializer.SOAPdeserialisation(false);

            //t3
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("xml.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode nd = xRoot.FirstChild;
            XmlNodeList list = xRoot.ChildNodes;
            Console.WriteLine(nd.OuterXml);
            foreach (XmlNode xn in list)
            {
                Console.WriteLine(xn.OuterXml);
            }

            //t4
            XDocument xdoc = XDocument.Load("xml1.xml");
            var items = from xe in xdoc.Element("xml").Elements()
                        where Convert.ToInt32(xe.Element("length").Value) >= 2
                        select xe.Element("length").Value;
            foreach (string k in items)
            {
                Console.WriteLine(k);
            }

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}

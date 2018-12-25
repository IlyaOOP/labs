using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;

namespace lab14_XAMARIN
{
	[System.Serializable]
	class куст
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
			return (this.GetType()+ "\nвысота: " + length + "\nраспространенность: " + prevalence);
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
			BinaryFormatter bf = new BinaryFormatter ();

			using (FileStream fs = new FileStream ("binary.dat", FileMode.OpenOrCreate)) {
				bf.Serialize (fs, obj);
				Console.WriteLine ("binary serialisation");
			}
		}
		public static void binaryDeserealisation(object obj)
		{
			BinaryFormatter bf = new BinaryFormatter ();

			using (FileStream fs = new FileStream ("binary.dat", FileMode.OpenOrCreate)) {
				var objec = bf.Deserialize (fs);
				Console.WriteLine ("binary deserialisation");
				куст kbin = (куст)objec;
				Console.WriteLine ("object: "+kbin);
			}
		}

		public static void SOAPSerialization(object obj)
		{
			SoapFormatter sf = new SoapFormatter ();

			using (FileStream fs = new FileStream("soap.soap", FileMode.OpenOrCreate))
			{
				sf.Serialize(fs, obj);

				Console.WriteLine("SOAP serialisation");
			}
		}
		public static void SOAPdeserialisation(object obj)
		{
			SoapFormatter sf = new SoapFormatter ();

			using (FileStream fs = new FileStream("soap.soap", FileMode.OpenOrCreate))
			{
				var objec = sf.Deserialize (fs);
				Console.WriteLine ("SOAP deserialisation");
				куст kbin = (куст)objec;
				Console.WriteLine ("object: "+kbin);
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
		public static void JSONdeserialisation(object obj)
		{
			DataContractJsonSerializer jf = new DataContractJsonSerializer(obj.GetType());

			using (FileStream fs = new FileStream("json.json", FileMode.OpenOrCreate))
			{
				var objec = jf.ReadObject(fs);
				Console.WriteLine("JSON serialisation");
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
		public static void XMLdeserialisation(object obj)
		{
			XmlSerializer xs = new XmlSerializer(obj.GetType());

			using (FileStream fs = new FileStream("xml.xml", FileMode.OpenOrCreate))
			{
				var objec = xs.Deserialize(fs);
				Console.WriteLine("XML deserialisation");
			}
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			Console.ReadKey ();
		}
	}
}

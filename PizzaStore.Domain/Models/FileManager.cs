using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaStore.Domain.Models
{
	public class FileManager
	{
		private const string _path = @"data/pizza_store.xml";
		public Order Read()
		{
			var reader = new StreamReader(_path);
			var xml = new XmlSerializer(typeof(Order));
			return xml.Deserialize(reader) as Order;
		}

		public void Write(Order order)
		{
			// var path = @"data/pizza_store.xml";  // Create a file.
			var writer = new StreamWriter(_path); //Open File with write permission
			var xml = new XmlSerializer(typeof(Order)); //Load Content to Write.
			xml.Serialize(writer, order); // Convert content to xml

		}
	}
}
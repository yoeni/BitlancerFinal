using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bitlancer
{
	public sealed class SingletonDB
	{
		private static SingletonDB instance = null;

		public static SingletonDB GetInstance
		{
			get
			{
				if (instance == null)
					instance = new SingletonDB();
				return instance;
			}
		}

		private SingletonDB()
		{
		}
		public MySqlConnection getConnection()
		{
			MySqlConnection connection = null;
			try
			{
				connection = new MySqlConnection("server=localhost;port=3307;user=root;pwd=;database=bitlancer;charset=utf8;pooling=false");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return connection;
		}
		public int getId(string sql)
		{
			int id = 0;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand(sql, connection);
				id = Convert.ToInt32(command.ExecuteScalar());
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return id;
		}
		public double getDouble(string sql)
		{
			double val = 0;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand(sql, connection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					val = Convert.ToDouble(reader[0]);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return val;
		}
		public int updateitem(int id)
		{
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				Random rnd = new Random();
				command = new MySqlCommand("update item_user_infos set unit_price=" + id + " where id=6", connection);
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return id;
		}
		public int loginCheck(string userName, string password)
		{
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select user_name, user_password from users", connection);
				command.Connection = connection;
				MySqlDataReader read = command.ExecuteReader();
				while (read.Read())
				{
					if (read[0].ToString() == userName && read[1].ToString() == password)
					{
						state = true;
						break;

					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("hata: " + e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state ? getId("select id from users where user_name='" + userName + "'") : 0;

		}
		public item getItem(int id)
		{
			item myItem = new item();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select * from items where id=" + id, connection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					myItem.id = int.Parse(reader[0].ToString());
					myItem.itemName = reader[1].ToString();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return myItem;
		}
		public List<item> getItemBitlancer(int balance=1)
		{
			List<item> items=new List<item>();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select * from items where balance="+balance, connection);
				command.Connection = connection;
				MySqlDataReader read = command.ExecuteReader();
				while (read.Read())
				{
					item urun = new item();
					urun.id = Convert.ToInt32(read[0]);
					urun.itemName = read[1].ToString();
					items.Add(urun);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("hata: " + e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return items;
		}
		public DataTable getItems()
		{
			DataTable dt = new DataTable();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select (row_number() over (order by i.item_name))as 'No:', i.item_name as 'Para Birimi:',concat(min(f.unit_price),' ₺') as 'Biriim Fiyat:',i.id from items i, item_user_infos f where  i.id=f.item_id and i.id!=4 and f.selling=1 GROUP by f.item_id order by i.item_name", connection);
				dt.Load(command.ExecuteReader());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return dt;
		}
		public item getItemOrder(int id, int userID)
		{
			item urun = new item();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select item_id, min(unit_price), sum(quantity),(select item_name from items where id=s.item_id) from item_user_infos s where selling=1 and item_id=" + id, connection);
				command.Connection = connection;
				MySqlDataReader read = command.ExecuteReader();
				while (read.Read())
				{
					urun.id = Convert.ToInt32(read[0]);
					urun.unitPrice = Convert.ToDouble(read[1]);
					urun.quantity = Convert.ToInt32(read[2]);
					urun.itemName = read[3].ToString();
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("hata: " + e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return urun;
		}
		public DataTable getItemTransfers(int id)
		{
			DataTable dt = new DataTable();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select (row_number() over (order by f.id desc))as 'No:', i.item_name as 'Ürün:',concat(min(f.unit_price),' ₺') as 'Birim Fiyat:',f.quantity as 'Adet:', f.date as 'Tarih:',f.state as 'Durum:',f.description as 'Açıklama:' from items i, item_adds f where  i.id=f.item_id and f.user_id=" + id + " GROUP by f.item_id", connection);
				dt.Load(command.ExecuteReader());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return dt;
		}
		public bool setItemTransfer(int userID,int itemID,int quantity)
		{
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				Random rnd = new Random();
				command = new MySqlCommand("insert into item_adds(user_id,item_id,quantity,unit_price,state,description,date) values("+userID+","+itemID+","+quantity+",1,0,'BEKLENİYOR','"+DateTime.Now.ToString()+"')", connection);
				command.ExecuteNonQuery();
				state = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				state = false;
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state;
		}
		public DataTable getLastOrders(int id = 0, int item_id = 0)
		{
			DataTable dt = new DataTable();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			string toUserOrder = "", toAdmin = "", whereClause = "";
			if (id != 0)
			{
				toUserOrder = "(CASE WHEN destination_user_id=" + id + " THEN 'ALIM' ELSE 'SATIM' END) as 'İşlem: ',";
				whereClause = "where " + (item_id != 0 ? "item_id=" + item_id + " and (" : "") + "destination_user_id=" + id + " or source_user_id=" + id + (item_id != 0 ? ")" : "");
			}
			else
			{
				toAdmin = " (select user_full_name from users where id = o.destination_user_id) as 'Hedef:',(select user_full_name from users where id = o.source_user_id) as 'Kaynak: ',";
			}
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select row_number() over(order by id desc) as 'No:'," + toUserOrder + " order_date as 'Tarih:'," + toAdmin + " (select item_name from items where id = o.item_id) as 'Ürün:',(order_quantity * order_unit_price) as 'Tutar:',(select quantity from item_user_infos where user_id = " + (id!=0?id.ToString():"o.destination_user_id") + " and item_id = 4) as 'Kalan Para:',order_unit_price as 'Birim Fiyat:' from item_orders o " + whereClause, connection);
				dt.Load(command.ExecuteReader());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return dt;
		}
		public DataTable getLastOrdersWait(int id = 0)
		{
			DataTable dt = new DataTable();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select row_number() over(order by id desc) as 'No:',date as 'Tarih:', (select item_name from items where id = o.item_id) as 'Para Birimi:',quantity as 'Miktar:',unit_price as 'Birim Fiyat:' from item_orders_wait o where user_id="+id, connection);
				dt.Load(command.ExecuteReader());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return dt;
		}
		public DataTable getLastOrderBetwenDate(int id, DateTime date1,DateTime date2)
		{
			DataTable dt = new DataTable();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			string dt1 = date1.ToString("yyyy-MM-dd");
			string dt2 = date2.ToString("yyyy-MM-dd");
			string toUserOrder = "(CASE WHEN destination_user_id=" + id + " THEN 'ALIM' ELSE 'SATIM' END) as 'İşlem: ',";
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select row_number() over(order by id desc) as 'No:', "+toUserOrder+"order_date as 'Tarih:', (select item_name from items where id = o.item_id) as 'Ürün:',order_quantity as 'Miktar:',(order_quantity * order_unit_price) as 'Tutar:',order_unit_price as 'Birim Fiyat:' from item_orders o where (destination_user_id="+id+" or source_user_id="+id+ ") and (DATE(concat(RIGHT(LEFT(order_date,10),4),'-',SUBSTRING(order_date,4,2),'-',LEFT(order_date,2))) BETWEEN CAST('"+dt1+"' as DATE) and CAST('"+dt2+"' as DATE))", connection);
				dt.Load(command.ExecuteReader());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return dt;
		}
		public User getUser(int id)
		{
			User myUser = new User();
			List<item> MyItems = new List<item>();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select * from item_user_infos inner join items on item_user_infos.item_id=items.id where user_id=" + id, connection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					item tempItem = new item(int.Parse(reader[2].ToString()), reader[7].ToString(), Convert.ToDouble(reader[4].ToString()), int.Parse(reader[3].ToString()), (bool)reader[5]);
					MyItems.Add(tempItem);
				}
				reader.Close();
				command = new MySqlCommand("select * from users where id=" + id, connection);
				reader = command.ExecuteReader();
				while (reader.Read())
				{
					myUser = new User(id, reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), reader[8].ToString() == "5" ? bitlancer.userTypes.admin : bitlancer.userTypes.basic, MyItems);
				}

			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return myUser;
		}
		public bool setItemOrder(int userIDSource, int userIDDestination, int itemID, int orderQuantity, double unitPrice)
		{
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				Random rnd = new Random();
				command = new MySqlCommand("insert into item_orders (destination_user_id,source_user_id,item_id,order_unit_price,order_quantity,order_date) values(" + userIDDestination + "," + userIDSource + "," + itemID + ",'" + unitPrice.ToString().Replace(",", ".") + "'," + orderQuantity + ",'" + DateTime.Now.ToString() + "')", connection);
				command.ExecuteNonQuery();
				state = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				state = false;
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state;
		}
		public bool updateAfterOrder(int selling, int sourceID, int itemID, int quantity, double unitPrice = 1, bool delete = false)
		{
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				string sorgu;
				if (delete)
				{
					sorgu = "delete from item_user_infos where selling=" + selling + " and (item_id=" + itemID + " and user_id=" + sourceID + ")";
				}
				else
				{
					if (getId("select id from item_user_infos where selling=" + selling + " and (item_id=" + itemID + " and user_id=" + sourceID + ")") != 0)
					{
						sorgu = "update item_user_infos set quantity=" + quantity + " where  selling=" + selling + " and (item_id=" + itemID + " and user_id=" + sourceID + ")";
					}
					else
					{
						sorgu = "insert into item_user_infos (user_id,item_id,quantity,unit_price,selling) values (" + sourceID + "," + itemID + "," + quantity + ",'" + unitPrice.ToString().Replace(",", ".") + "',0)";
					}
				}
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand(sorgu, connection);
				command.ExecuteNonQuery();
				state = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				state = false;
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state;
		}
		public bool updateOrderToSell(int sourceID, int itemID, int quantity, int All0, int All1, double unitPrice)
		{
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				string sorgum = "";
				if (quantity == All0 && All1 == 0)
				{
					sorgum = "update item_user_infos set selling=1,unit_price='" + unitPrice.ToString().Replace(",", ".") + "' where user_id=" + sourceID + " and item_id=" + itemID;

				}
				else
				{
					if (getId("select id from item_user_infos where selling=1 and (item_id=" + itemID + " and user_id=" + sourceID + ")") != 0)
					{
						int now = getId("select quantity from item_user_infos where selling=1 and (item_id=" + itemID + " and user_id=" + sourceID + ")");
						sorgum = "update item_user_infos set quantity=" + (now + quantity) + ",unit_price=" + unitPrice.ToString().Replace(",", ".") + " where selling=1 and (item_id=" + itemID + " and user_id=" + sourceID + ");";
					}
					else
					{
						sorgum = "insert into item_user_infos (user_id,item_id,quantity,unit_price,selling) values (" + sourceID + "," + itemID + "," + quantity + ",'" + unitPrice.ToString().Replace(",", ".") + "',1);";
					}
					sorgum += "update item_user_infos set quantity=" + (All0 - quantity) + " where selling=0 and (item_id=" + itemID + " and user_id=" + sourceID + ")";
					if (quantity == All0)
					{
						sorgum += ";delete from item_user_infos where selling=0 and (item_id=" + itemID + " and user_id=" + sourceID + ")";
					}
				}
				connection = getConnection();
				connection.Open();
				Random rnd = new Random();
				command = new MySqlCommand(sorgum, connection);
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state;
		}
		public void manageOrder(int userID, int itemID, int quantity, bitlancer.orderTypes orderType, double unitPriceSell = 0)
		{
			if (orderType == bitlancer.orderTypes.buy)
			{
				int minItemQuantity = getId("select quantity from item_user_infos where unit_price=(select min(unit_price) from item_user_infos where item_id="+itemID+" and selling=1 and user_id!=" + userID+") and (item_id=" + itemID+" and selling=1 and user_id!="+userID+")");
				int tlITemQuantity = getId("select quantity from item_user_infos where item_id=4 and user_id=" + userID);
				int destItemqQuantity = getId("select quantity from item_user_infos where selling=0 and (item_id=" + itemID + " and user_id=" + userID + ")");
				if (quantity == minItemQuantity)
				{
					int sourceId = getId("select user_id from item_user_infos where unit_price=(select min(unit_price) from item_user_infos where item_id=" + itemID + " and selling=1 and user_id!=" + userID + ") and (item_id=" + itemID + " and selling=1 and user_id!=" + userID + ")");
					int sourceIdTL = getId("select quantity from item_user_infos where item_id=4 and user_id=" + sourceId);
					double unitPrice = getDouble("select unit_price from item_user_infos where selling=1 and (item_id=" + itemID + " and user_id=" + sourceId + ")");
					if (tlITemQuantity >= (quantity * (int)unitPrice))
					{
						setItemOrder(sourceId, userID, itemID, quantity, unitPrice);
						updateAfterOrder(1, sourceId, itemID, 0, unitPrice, true);
						updateAfterOrder(0, userID, itemID, destItemqQuantity + quantity, unitPrice);
						updateAfterOrder(0, userID, 4, tlITemQuantity - (quantity * (int)unitPrice), 1);
						updateAfterOrder(0, sourceId, 4, sourceIdTL + (quantity * (int)unitPrice), 1);
					}
				}
				else
				{
					List<orderUpdateItem> myItems = getItemsById(itemID);
					foreach (orderUpdateItem item in myItems)
					{
						while (quantity != 0)
						{
							int sourceId = getId("select user_id from item_user_infos where unit_price=(select min(unit_price) from item_user_infos where item_id=" + itemID + " and selling=1 and user_id!=" + userID + ") and (item_id=" + itemID + " and selling=1 and user_id!=" + userID + ")");
							if (sourceId != 0)
							{
								int sourceIdTL = getId("select quantity from item_user_infos where item_id=4 and user_id=" + sourceId);
								double unitPrice = getDouble("select unit_price from item_user_infos where selling=1 and (item_id=" + itemID + " and user_id=" + sourceId + ")");
								int miktar = minItemQuantity > quantity ? quantity : minItemQuantity;
								if (tlITemQuantity < (miktar * (int)unitPrice))
								{
									quantity--;
								}
								else
								{
									setItemOrder(sourceId, userID, itemID, miktar, unitPrice);
									if (minItemQuantity <= quantity)
										updateAfterOrder(1, sourceId, itemID, 0, unitPrice, true);
									else
										updateAfterOrder(1, sourceId, itemID, minItemQuantity - miktar, unitPrice);
									updateAfterOrder(0, userID, itemID, destItemqQuantity + miktar, unitPrice);
									updateAfterOrder(0, userID, 4, tlITemQuantity - (miktar * (int)unitPrice), 1);
									updateAfterOrder(0, sourceId, 4, sourceIdTL + (miktar * (int)unitPrice), 1);
									quantity -= miktar;
									destItemqQuantity += miktar;
									minItemQuantity = getId("select quantity from item_user_infos where unit_price=(select min(unit_price) from item_user_infos where item_id=" + itemID + " and selling=1 and user_id!=" + userID + ") and (item_id=" + itemID + " and selling=1 and user_id!=" + userID + ")");
									tlITemQuantity = getId("select quantity from item_user_infos where item_id=4 and user_id=" + userID);
									destItemqQuantity = getId("select quantity from item_user_infos where selling=0 and (item_id=" + itemID + " and user_id=" + userID + ")");
								}
							}
							else
							{
								quantity = 0;
							}
						}
					}
				}
			}
			else
			{
				int myAllQuantity = getId("select quantity from item_user_infos where selling=0 and (item_id=" + itemID + " and user_id=" + userID + ")");
				int myAllQuantity2 = getId("select quantity from item_user_infos where selling=1 and (item_id=" + itemID + " and user_id=" + userID + ")");
				updateOrderToSell(userID, itemID, quantity, myAllQuantity, myAllQuantity2, unitPriceSell);
			}
		}
		public List<orderUpdateItem> getItemsById(int itemID)
		{
			List<orderUpdateItem> items = new List<orderUpdateItem>();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("select user_id,quantity,unit_price from item_user_infos where item_id=" + itemID, connection);
				MySqlDataReader reader = command.ExecuteReader();
				while (reader.Read())
				{
					orderUpdateItem myItem = new orderUpdateItem();
					myItem.id = itemID;
					myItem.sourceId = int.Parse(reader[0].ToString());
					myItem.unitPrice = Convert.ToDouble(reader[2]);
					myItem.quantity = int.Parse(reader[1].ToString());
					items.Add(myItem);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return items;
		}
		public bool updateUser(int id, string userName, string fullName, string password, string tel, string mail, string address)
		{
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("update users set user_name='" + userName + "', user_full_name='" + fullName + "', user_password='" + password + "', user_tel='" + tel + "', user_mail='" + mail + "', user_address='" + address + "' where id=" + id, connection);
				command.ExecuteNonQuery();
				state = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				state = false;
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state;
		}
		public void uptadeAdminOnayDataGrid(int id, int state, string description, double unit_price=1)
		{ 
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				Random rnd = new Random();
				command = new MySqlCommand("update item_adds set state =" + state + ",unit_price="+unit_price.ToString().Replace(",",".")+", description ='" + description + "' where id="+id , connection);
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
		}
		public DataTable GetTable(string sql)
        {
			DataTable dt = new DataTable();
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand(sql, connection);
				dt.Load(command.ExecuteReader());
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return dt;
		}
		public bool userRegister(string userFullName,string userName, string userPassword, string userAddres,string userMail,string userTc,string userTel)
		{
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("insert into users(user_full_name,user_name,user_password,user_address,user_mail,user_tc,user_tel,user_type_id) values ('" + userFullName+"','" +userName + "','" + userPassword+"','" + userAddres + "','" + userMail + "','" + userTc+ "','" + userTel + "','" + 6 + "')", connection);
				command.ExecuteNonQuery();
				state = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				state = false;
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state;
		}
		public bool addOrderWait(int userId,int itemId,int quantity,double unitPrice)
        {
			bool state = false;
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("insert into item_orders_wait(user_id,item_id,quantity,unit_price,date) values (" + userId + "," + itemId + "," + quantity + "," + unitPrice.ToString().Replace(",", ".") + ",'" + DateTime.Now.ToString() + "')", connection);
				command.ExecuteNonQuery();
				state = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				state = false;
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			return state;
        }
		public void updateWaitingOrder(int id)
        {
			MySqlConnection connection = null;
			MySqlCommand command = null;
			try
			{
				connection = getConnection();
				connection.Open();
				command = new MySqlCommand("delete from item_orders_wait where id=" + id, connection);
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			finally
			{
				if (connection != null)
				{
					try
					{//bağlantıları kapat
						connection.Close();
						command.Dispose();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
		}
		public void checkOrderWaits()
		{
			DataTable waitingOrders = GetTable("select * from item_orders_wait");
            if (waitingOrders.Rows.Count!=0)
			{
				foreach (DataRow row in waitingOrders.Rows)
				{
					double wantedPrice = Convert.ToDouble(row[4].ToString());
					double minPrice = getDouble("select min(unit_price) from item_user_infos where user_id!="+ row[1].ToString() + " and (item_id=" + row[2].ToString() + " and selling=1)");

					if (wantedPrice >= minPrice)
					{
						manageOrder(int.Parse(row[1].ToString()), int.Parse(row[2].ToString()), int.Parse(row[3].ToString()), bitlancer.orderTypes.buy);
						updateWaitingOrder(int.Parse(row[0].ToString()));
					}
				}
			}
		}
	}
}
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Library.DB
{
	public class ExchangeRatesDB
	{
		#region Fields
		private readonly string? CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["ExchangeRatesDB_ConnectionString"].ConnectionString;
		private IDbConnection? _connection;
		public bool IsConnected { get; protected set; }
		#endregion


		#region Events and Delegates
		public delegate void DatabaseMessageDelegate(string message);
		public event DatabaseMessageDelegate? DatabaseMessage;
		#endregion


		#region Connect/Disonnect
		public void ConnectBase()
		{
			_connection?.Dispose();

			try
			{
				_connection = new SqlConnection(CONNECTION_STRING);
				_connection.Open();
			}
			catch (Exception ex)
			{
				DatabaseMessage?.Invoke(ex.Message);
				return;
			}

			IsConnected = true;
			DatabaseMessage?.Invoke("The connection to the DATABASE was successfully established.");
		}


		public void DisconnectBase()
		{
			if (_connection is not null)
			{
				_connection.Dispose();
				IsConnected = false;
				DatabaseMessage?.Invoke("The connection to the DATABASE was interrupted.");
			}
		}
		#endregion


		#region Queries
		public async Task AddClient(string login, string password, int limitQueries)
		{
			await Task.Run(() =>
			{
				try
				{
					var parameters = new { Login = login, Password = password, LimitQueries = limitQueries };
					_connection.Execute("AddClient", parameters, commandType: CommandType.StoredProcedure);
				}
				catch (SqlException ex)
				{
					DatabaseMessage?.Invoke(ex.Message);
				}
			});
		}


		public async Task<int?> GetClientId(string login, string password)
		{
			return await Task.Run<int?>(() =>
			{
				int id = _connection.QuerySingleOrDefault<int>(
					"SELECT Id FROM Clients WHERE Login = @Login AND Password = @Password",
					new { Login = login, Password = password });

				if (id is not default(int))
					return id;
				else
					return null;
			});
		}


		public async Task<int?> GetLimitQueriesById(int clientId)
		{
			return await Task.Run<int?>(() =>
			{
				int limitQuotes = _connection.QuerySingleOrDefault<int>(
					"SELECT LimitQueries FROM Clients WHERE Id = @Id",
					new { Id = clientId });

				if (limitQuotes is not default(int))
					return limitQuotes;
				else
					return null;
			});
		}


		public async Task AddLogClientsQueries(int clientId, string fromCurrency, string toCurrency)
		{
			await Task.Run(() =>
			{
				try
				{
					var parameters = new { ClientId = clientId, FromCurrency = fromCurrency, ToCurrency = toCurrency };
					_connection.Execute("AddLogClientsQueries", parameters, commandType: CommandType.StoredProcedure);
				}
				catch (SqlException ex)
				{
					DatabaseMessage?.Invoke(ex.Message);
				}
			});
		}


		public void AddLogConnectionDisconnection(int clientId, string storedProc)
		{
			try
			{
				var parameters = new { ClientId = clientId, Date = DateTime.Now };
				_connection.Execute(storedProc, parameters, commandType: CommandType.StoredProcedure);
			}
			catch (SqlException ex)
			{
				DatabaseMessage?.Invoke(ex.Message);
			}
		}
		#endregion
	}
}

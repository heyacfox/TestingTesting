using UnityEngine;
using System.Collections;

public class PizzaOrderer
{
	private IServerConnector serverConnector;
	private IPaymentValidator pizzaPaymentValidator;

	public void MakeOrder (string pizzaName)
	{
		if (pizzaPaymentValidator.IsPaymentAccepted ())
			serverConnector.SendRequestForPizza (pizzaName);
	}

	public void SetServerConnector (IServerConnector serverConnector)
	{
		this.serverConnector = serverConnector;
	}

	public void SetPaymentValidator (IPaymentValidator pizzaPaymentValidator)
	{
		this.pizzaPaymentValidator = pizzaPaymentValidator;
	}
}

public interface IPaymentValidator
{
	bool IsPaymentAccepted();
}

public interface IServerConnector
{
	void SendRequestForPizza(string pizzaName);
}

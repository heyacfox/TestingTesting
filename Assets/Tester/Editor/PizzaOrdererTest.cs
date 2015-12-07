using UnityEngine;
using System.Collections;
using NUnit;
using NSubstitute;
using System;
using NUnit.Framework;


public class PizzaOrdererTest {

	[Test]
	public void OrderedSuccessfully ()
	{
		//Setup the test
		IPaymentValidator paymentValidatorMock = GetValidatorMock ();
		IServerConnector connectorMock = GetConnectorMock ();
		var pizzaOrderer = new PizzaOrderer ();
		pizzaOrderer.SetPaymentValidator (paymentValidatorMock);
		pizzaOrderer.SetServerConnector (connectorMock);

		//Invoke the tested method
		pizzaOrderer.MakeOrder ("Unity pizza with extra cheese");

		//verify that the send request for pizza from IServerConnector was called with the given argument
		//connectorMock.Received (1).SendRequestForPizza (EventArgs.Is ("Unity pizza with extra cheese"));
		//NSubstitute.Received.InOrder(connectorMock.SendRequestForPizza("Unity pizza with extra cheese"));
		connectorMock.Received (1).SendRequestForPizza ("Unity pizza with extra cheese");

	}

	private IServerConnector GetConnectorMock()
	{
		return Substitute.For<IServerConnector> ();
	}

	private IPaymentValidator GetValidatorMock()
	{
		var mock = Substitute.For<IPaymentValidator> ();
		//make IsPaymentAccepted always return true
		//NSubstitute.Core.ReturnValueFromFunc<mock.IsPaymentAccepted()>(true);
		mock.IsPaymentAccepted ().Returns (true);
		return mock;
	}
}

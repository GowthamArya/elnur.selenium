﻿// See https://aka.ms/new-console-template for more information
using elnur.selenium.HomePage;

public class Program
{
	public static void Main(string[] args)
	{
		Header header = new Header();
		Header.TestHeaderNavigate();
	}
}

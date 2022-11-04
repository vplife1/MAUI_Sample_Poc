﻿using FirstApp.View;

namespace FirstApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new ShowEmployeePage());
    }
}

using FirstApp.Model;
using FirstApp.Repository;

namespace FirstApp;

public partial class MainPage : ContentPage
{
	int count = 0;
   public PersonRepository personRepository = PersonRepository.Instance;
    public MainPage()
	{
		InitializeComponent();
	}

    //private void OnCounterClicked(object sender, EventArgs e)
    //{
    //	count++;

    //	if (count == 1)
    //		CounterBtn.Text = $"Clicked {count} time";
    //	else
    //		CounterBtn.Text = $"Clicked {count} times Vivek PAWAR";

    //	 if (count == 38)
    //		CounterBtn.Text = "NO Need to show";

    //	SemanticScreenReader.Announce(CounterBtn.Text);
    //}
    public void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        personRepository.AddNewPerson(newPerson.Text);
        statusMessage.Text = personRepository.StatusMessage;
    }

    public void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Person> people = personRepository.GetAllPeople();
        peopleList.ItemsSource = people;
    }
}


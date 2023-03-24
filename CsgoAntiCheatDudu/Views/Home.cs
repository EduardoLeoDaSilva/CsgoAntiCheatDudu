using CsgoAntiCheatDudu;

namespace CsAntiCheat.Views
{
    public partial class Home : Form
    {
        private readonly HostedService _service;
        private System.Threading.Timer t;
        private System.Threading.Timer t2;

        public Home(ServiceProvider serviceProvider)
        {
            InitializeComponent();
            _service = serviceProvider.GetRequiredService<HostedService>();



            t = new System.Threading.Timer(TimerCallback, null, 0, 5000);
            t2 = new System.Threading.Timer(TimerCallback2, null, 0, 100);





        }

        public delegate void TimerCallbackDelegate(object o);

        public async void TimerCallback(Object o)
        {

            try
            {

                //Verifica se é necessário invocar esse método na thread principal para interagir com os controles
                if (InvokeRequired)
                {
                    //Invoca este próprio método
                    Invoke((TimerCallbackDelegate)TimerCallback, o);

                }
                else
                {

                    //Aqui seu código estará rodando na thread principal e será possível interagir com os componentes
                    await _service.StartVerification();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public delegate void TimerCallbackDelegate2(object o);


        public async void TimerCallback2(Object o)
        {

            try
            {

                //Verifica se é necessário invocar esse método na thread principal para interagir com os controles
                if (InvokeRequired)
                {
                    //Invoca este próprio método
                    Invoke((TimerCallbackDelegate2)TimerCallback2, o);

                }
                else
                {

                    //Aqui seu código estará rodando na thread principal e será possível interagir com os componentes
                    var message = _service.Messages.Last();
                    this.label1.Text = message;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

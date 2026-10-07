namespace CentralAtendimento
{
    public class Program
    {
        static void Main(string[] args)
        {
            CallCenter center = new CallCenter();

            // Uma thread para os chamadores e tres para os consultores, rodando ao mesmo tempo
            Parallel.Invoke(
                () => CallersAction(center),
                () => ConsultantAction(center, "Marcin",
                    ConsoleColor.Red),
                () => ConsultantAction(center, "James",
                    ConsoleColor.Yellow),
                () => ConsultantAction(center, "Olivia",
                    ConsoleColor.Green));
        }

        private static void CallersAction(CallCenter center)
        {
            Random random = new Random();
            while (true)
            {
                int clientId = random.Next(1, 10000);
                int waitingCount = center.Call(clientId);
                Log($"Chamada recebida do cliente {clientId}, " +
                    $"esperando na fila: {waitingCount}");
                Thread.Sleep(random.Next(1000, 5000));
            }
        }

        private static void ConsultantAction(CallCenter center,
            string name, ConsoleColor color)
        {
            Random random = new Random();
            while (true)
            {
                IncomingCall? call = center.Answer(name);
                if (call != null)
                {
                    Console.ForegroundColor = color;
                    Log($"Chamada #{call.Id} do cliente {call.ClientId} " +
                        $"atendida por {call.Consultant}.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    // Simula a duracao da ligacao (entre 1 e 10 segundos)
                    Thread.Sleep(random.Next(1000, 10000));
                    center.End(call);

                    Console.ForegroundColor = color;
                    Log($"Chamada #{call.Id} do cliente {call.ClientId} " +
                        $"encerrada por {call.Consultant}.");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    // Intervalo entre o fim de uma ligacao e o inicio de outra
                    Thread.Sleep(random.Next(500, 1000));
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        private static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}] {text}");
        }
    }
}

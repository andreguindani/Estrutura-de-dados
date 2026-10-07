using System.Collections.Concurrent;

namespace CentralAtendimento
{
    public class CallCenter
    {
        private int _counter = 0;

        // Fila thread-safe, pois varias threads (chamadores e consultores) acessam ao mesmo tempo
        public ConcurrentQueue<IncomingCall> Calls { get; private set; }

        public CallCenter()
        {
            Calls = new ConcurrentQueue<IncomingCall>();
        }

        // Adiciona uma nova chamada na fila e retorna quantas estao esperando
        public int Call(int clientId)
        {
            IncomingCall call = new IncomingCall()
            {
                Id = ++_counter,
                ClientId = clientId,
                CallTime = DateTime.Now
            };
            Calls.Enqueue(call);
            return Calls.Count;
        }

        // ConcurrentQueue nao tem Dequeue, entao usamos o TryDequeue
        public IncomingCall? Answer(string consultant)
        {
            if (Calls.Count > 0
                && Calls.TryDequeue(out IncomingCall? call))
            {
                call.Consultant = consultant;
                call.StartTime = DateTime.Now;
                return call;
            }
            return null;
        }

        public void End(IncomingCall call)
        {
            call.EndTime = DateTime.Now;
        }

        public bool AreWaitingCalls()
        {
            return Calls.Count > 0;
        }
    }
}

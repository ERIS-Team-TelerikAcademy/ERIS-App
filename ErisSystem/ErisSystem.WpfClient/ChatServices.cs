namespace ErisSystem.WpfClient
{
    using IronSharp.Core;
    using IronSharp.IronMQ;
    using System.Collections.Generic;

    public class ChatServices
    {
        private IronMqRestClient ironMq;

        private QueueClient currentQueue;

        //Will move to services project maybe
        public ChatServices()
        {
            this.ironMq = Client.New(
                new IronClientConfig {
                    ProjectId = "56420b6f9195a800080000b6",
                    Token = "ANgrGMpOtkzSxbTIlWbk",
                    Host = "mq-aws-eu-west-1-1.iron.io", ApiVersion = 3
                });

            this.currentQueue = this.ironMq.Queue("Some");
        }
        public void Send(string message)
        {
            this.currentQueue.Post(message);
        }

        public QueueMessage Receve()
        {
            var msg = this.currentQueue.Reserve();
            return msg;
        }

        public MessageCollection ReceveAll()
        {
            var queueInfo = this.currentQueue.Info();
            var msgCount = queueInfo.TotalMessages;
            var msges = this.currentQueue.Reserve(msgCount);

            return msges;
        }

        public void SwitchRoom(string roomName) // if queue name isnt in server it autocreates it
        {
            this.currentQueue = this.ironMq.Queue(roomName);
        }

        public IEnumerable<QueueInfo> GetAllRooms()
        {
           var result = this.ironMq.Queues();

            return result;
        }
    }
}

namespace ErisSystem.WpfClient
{
    using IronSharp.Core;
    using IronSharp.IronMQ;
    using System;
    using System.Collections.Generic;

    public class ChatServices
    {
        private IronMqRestClient ironMq;

        private QueueClient currentQueue;

        private List<string> msgCache = new List<string>();

        //Will move to services project maybe
        public ChatServices()
        {
            this.ironMq = Client.New(
                new IronClientConfig
                {
                    ProjectId = "56420b6f9195a800080000b6",
                    Token = "ANgrGMpOtkzSxbTIlWbk",
                    Host = "mq-aws-eu-west-1-1.iron.io",
                    ApiVersion = 3
                });

            this.currentQueue = this.ironMq.Queue("Global");
        }
        public void Send(string message)
        {
            this.currentQueue.Post(message);
        }

        public QueueMessage Receve()
        {
            var msg = this.currentQueue.Next(new TimeSpan(0, 0, 30));
            if (msg != null)
            {
                if (!this.msgCache.Contains(msg.Id))
                {
                    msgCache.Add(msg.Id);
                    return msg;
                }

                return null;

            }
            else
            {
                return null;
            }
        }

        //public MessageCollection ReceveAll()
        //{
        //    var queueInfo = this.currentQueue.Info();
        //    var msgCount = queueInfo.TotalMessages;
        //    var msges = this.currentQueue.Reserve(msgCount, new TimeSpan(0, 0, 30));

        //    return msges;
        //}

        public void SwitchRoom(string roomName) // if queue name isnt in server it autocreates it
        {
            this.msgCache.Clear();
            this.currentQueue = this.ironMq.Queue(roomName);
            if(currentQueue != null)
            {
                var isNewRoom = currentQueue.Info() == null;
                if (isNewRoom)
                {
                    this.Send("Hello");
                }

                return;
            }
        }

        public IEnumerable<QueueInfo> GetAllRooms()
        {
            var result = this.ironMq.Queues();

            return result;
        }
    }
}

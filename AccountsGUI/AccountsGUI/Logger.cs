namespace AccountsGUI;

public static class Logger
    { 
        private static List<string> loginEvents;
        private static List<string> transactionEvents;

        public static void LoginHandler(object sender, LoginEventArgs args)
        {
            string PersonName = args.PersonName;
            string Success = args.Success.ToString();
        }

        public static void TransactionHandler(object sender, TransactionEventArgs args)
        {
            string PersonName;
            string Amount;
            string Operation;
            string Success;
        }

        public static void DispalyLoginEvents(string filename)
        {
            Console.WriteLine(loginEvents.Count);
        }

        public static void DisplayTransactionEvents()
        {
            Console.WriteLine(transactionEvents.Count);
        }
    }

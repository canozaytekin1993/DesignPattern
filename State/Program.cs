using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modified = new ModifiedState();
            modified.doAction(context);

            DeleteState deleted = new DeleteState();
            deleted.doAction(context);

            Console.WriteLine(context.GetState().ToString());
            Console.ReadLine();

            AddState added = new AddState();
            added.doAction(context);

            Console.ReadLine();
        }
    }

    interface IState
    {
        void doAction(Context context);

    }

    class ModifiedState : IState
    {
        #region Implementation of IState

        public void doAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        #region Overrides of Object

        public override string ToString()
        {
            return "Modified";
        }

        #endregion

        #endregion
    }

    class DeleteState : IState
    {
        #region Implementation of IState

        public void doAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);    
        }

        #region Overrides of Object

        public override string ToString()
        {
            return "Deleted";
        }

        #endregion

        #endregion
    }

    class AddState : IState
    {
        #region Implementation of IState

        public void doAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);    
        }

        #region Overrides of Object

        public override string ToString()
        {
            return "Added";
        }

        #endregion

        #endregion
    }

    class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}

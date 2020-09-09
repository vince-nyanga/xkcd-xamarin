using System.Windows.Input;
using Xamarin.Forms;

namespace XKCDApp.Behaviors
{
    public class StepperValueChangedBehavior : Behavior<Stepper>
    {
        public ICommand Command { get; set; }

        protected override void OnAttachedTo(Stepper stepper)
        {
            stepper.ValueChanged += OnValueChanged;
            base.OnAttachedTo(stepper);
        }

        protected override void OnDetachingFrom(Stepper stepper)
        {
            stepper.ValueChanged -= OnValueChanged;
            base.OnDetachingFrom(stepper);
        }

        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (Command.CanExecute(e.NewValue))
            {
                Command.Execute(e.NewValue);
            }
        }
    }
}
    
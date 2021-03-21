namespace MainLibrary.Car
{
    public class Car
    {
        public readonly string CarName;

        public Car(string carName)
        {
            this.CarName = carName;
        }

        public override string ToString()
        {
            return $"Car: {CarName}";
        }
    }
}
public class Solution {
    public int MinMovesToSeat(int[] seats, int[] students) {
        List<int> seatsList = new List<int> (seats);
        List<int> studentsList = new List<int> (students);
        return Math.Abs(seats.Sum() - students.Sum());
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        if(solution is object)
        {
        }
    }
}
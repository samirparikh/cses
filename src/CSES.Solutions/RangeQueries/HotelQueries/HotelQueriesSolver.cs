using CSES.Core;

namespace CSES.Solutions.RangeQueries;

/// <summary>
/// Solver for CSES "Hotel Queries" problem.
/// Problem: https://cses.fi/problemset/task/1143
/// There are n hotels on a street. For each hotel you know the number of free
/// rooms. Your task is to assign hotel rooms for groups of tourists. All
/// members of a group want to stay in the same hotel.
/// The groups will come to you one after another, and you know for each group
/// the number of rooms it requires. You always assign a group to the first
/// hotel having enough rooms. After this, the number of free rooms in the hotel
/// decreases.
/// Input:
///     The first input line contains two integers n and m: the number of hotels
///     and the number of groups. The hotels are numbered 1,2,\ldots,n.
///     The next line contains n integers h_1,h_2,\ldots,h_n: the number of free
///     rooms in each hotel.
///     The last line contains m integers r_1,r_2,\ldots,r_m: the number of
///     rooms each group requires.
/// Output:
///     Print the assigned hotel for each group. If a group cannot be assigned a
///     hotel, print 0 instead.
/// </summary>
public class HotelQueriesSolver : ISolver
{
    private int MaxValue(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        return max;
    }

    public string Solve(string input)
    {
        var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var firstLineParts = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int numHotels = int.Parse(firstLineParts[0]);
        int numGroups = int.Parse(firstLineParts[1]);

        int[] freeRooms = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        int[] groupSizes = lines[2].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int[] assignedHotels = new int[numGroups];

        Console.WriteLine($"Number of hotels: {numHotels}, Number of groups: {numGroups}");
        Console.WriteLine($"Free rooms in hotels: {string.Join(", ", freeRooms)}");
        Console.WriteLine($"Group sizes: {string.Join(", ", groupSizes)}");

        for (int group = 0; group < numGroups; group++)
        {
            Console.WriteLine($"processing group of size {groupSizes[group]} ({group + 1}/{numGroups})");
            Console.WriteLine($"Current free rooms: {string.Join(", ", freeRooms)}");
            int assignedHotel = 0;

            for (int hotel = 0; hotel < numHotels; hotel++)
            {
                Console.WriteLine($"availability in hotel {hotel + 1}/{numHotels} = {freeRooms[hotel]}");
                if (groupSizes[group] <= freeRooms[hotel])
                {
                    assignedHotel = hotel + 1;
                    freeRooms[hotel] -= groupSizes[group];
                    Console.WriteLine($"assigning group {group + 1} to hotel {hotel + 1} which now has availability of {freeRooms[hotel]}");
                    break;
                }
            }
            assignedHotels[group] = assignedHotel;
        }


        return string.Join(" ", assignedHotels) + " ";
    }
}

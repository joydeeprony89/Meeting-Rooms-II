using System;
using System.Collections.Generic;

namespace Meeting_Rooms_II
{
  class Program
  {
    static void Main(string[] args)
    {
      var rooms = new int[6][] { new int[]{ 8, 12 }, new int[] { 1, 10 }, new int[] { 11, 30 },
                new int[] { 2, 7 }, new int[] { 10, 20 }, new int[]{ 3, 19 } };
    }
  }

  class Solution
  {
    // find the minimum number of conference rooms required
    public int MinMeetingRooms(List<int[]> intervals)
    {
      // Add the start times in this array
      int[] start = new int[intervals.Count];
      // Add the end times in this array
      int[] end = new int[intervals.Count];
      for (int i = 0; i < intervals.Count; i++)
      {
        start[i] = intervals[i][0];
        end[i] = intervals[i][1];
      }

      // Sort in Asc
      Array.Sort(start);
      // Sort in Asc
      Array.Sort(end);

      int start_p = 0, end_p = 0, noOfRooms = 1;
      for(int i = 0; i < start.Length; i++)
      {
        // When a meeting we wanted to start we check the start time of this is lesser than the on going meeting end time.
        // If yes - no need of extra meeting room, can utilize the free room.
        // when all meeting rooms are booked , meetings are going on, we need a new room so increment +1.
        // After allocating the room for the next meeting we can see the same issue we have to assign another meeting room , so +1 again.
        // We want to start another meeting and now one of the room is free, so now can utilize this free room
        // So we need two rooms atleast for the 3 meeting to have in a day
        if (start[start_p] < end[end_p]) noOfRooms++;
        else end_p++;
        start_p++;
      }

      return noOfRooms;
    }
  }
}

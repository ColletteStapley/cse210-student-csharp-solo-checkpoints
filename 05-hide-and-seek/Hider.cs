using System;
using System.Collections.Generic;

namespace _05_hide_and_seek
{
    /// <summary>
    /// The Hider is responsible to watch the seeker and give hints.
    /// 
    /// Stereotype:
    ///     Information Holder
    /// </summary>
    public class Hider
    {
        // TODO: Add any member variables here
        List<int> _distances;
        int _location1;
        /// <summary>
        /// Initializes the location of the hider to a random location 1-1000.
        /// Also initializes the list of distances to be a new, empty list.
        /// </summary>
        public Hider()
        {
            Random RandomGenerator = new Random();
            _distances = new List<int>();
            _location1 = RandomGenerator.Next(1,1001);
        }

        /// <summary>
        /// Computes the distance from the hider's location to the provided location of the seeker
        /// and stores it in a list of distances to use later.
        /// </summary>
        /// <param name="seekerLocation">The current location of the seeker.</param>
        public void Watch(int seekerLocation)
        {
            _distances.Add(Math.Abs(seekerLocation - _location1));
        }

        /// <summary>
        /// Get's a hint.
        /// 
        /// If there is not enough information yet (fewer than 2 distances), a generic hint is given.
        /// If the seeker has found the hider, the hint notes they have been found.
        /// If the seeker is moving closer, the hint notes they are getting warmer.
        /// If the seeker is moving futher away, the hing notes they are getting colder.
        /// </summary>
        /// <returns>The hint message</returns>
        public string GetHint(int seekerLocation)
        {
            string hint = "";
            if (_distances.Count < 2)
            {
                hint = "Keep on Looking!";
            }
            else
            {
                if (seekerLocation == _location1)
                {
                    hint = "You found me, Oh No *lol*";
                }
                else if (_distances[_distances.Count - 1] <= _distances[_distances.Count - 2])
                {
                    hint = "No, your getting too close go away!";
                }
                else if (_distances[_distances.Count - 1] > _distances[_distances.Count - 2])
                {
                 hint = "Oooh Yeah keep moving away from me!";
                }
            }
            return hint;
        }

        /// <summary>
        /// Returns whether the hider has been found. (Hint: the last distance is 0 in that case.)
        /// </summary>
        /// <returns>True if the hider has been found.</returns>
        public bool IsFound()
        {
            int last = _distances[_distances.Count - 1];
            if (last == 0)
            {
                return true;
            }
            return false;
        }
    }
}

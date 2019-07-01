using System;
using System.Collections.Generic;
using static RuneAggregateTree.RuneTree;

namespace RuneAggregateTree
{
    public interface IRuneDatabase
    {
        /// <summary>Adds a new game.</summary>
        /// <param name="rune">The game to add.</param>
        /// <returns>The new game.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rune"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="rune"/> is invalid.</exception>
        /// <exception cref="ArgumentException">A game with the same name already exists.</exception>
        Rune Add(Rune rune);

        /// <summary>Deletes a game.</summary>
        /// <param name="ID">The ID of the game.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ID"/> is less than or equal to 0.</exception>
        void Delete(int ID);

        /// <summary>Gets a game.</summary>
        /// <param name="ID">The ID of the game.</param>
        /// <returns>The game, if any.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="ID"/> is less than or equal to 0.</exception>
        Rune Get(int ID);

        /// <summary>Gets all games.</summary>
        /// <returns>The list of games.</returns>
        IEnumerable<Rune> GetAll();

        /// <summary>Updates an existing game.</summary>
        /// <param name="id">The ID of the existing game.</param>
        /// <param name="rune">The game to add.</param>
        /// <returns>The updated game.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rune"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to 0.</exception>
        /// <exception cref="ArgumentException">The game does not exist.
        /// <para>-or-</para>
        /// A game with the same name already exists.
        /// </exception>
        /// <exception cref="ValidationException"><paramref name="rune"/> is invalid.</exception>
        Rune Update(int id, Rune rune);
    }
}

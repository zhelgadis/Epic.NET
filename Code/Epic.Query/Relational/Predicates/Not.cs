//  
//  Not.cs
//  
//  Author:
//       Marco Veglio <m.veglio@gmail.com>
// 
//  Copyright (c) 2010-2012 Giacomo Tesio
// 
//  This file is part of Epic.NET.
// 
//  Epic.NET is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Epic.NET is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
// 
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//  
using System;

namespace Epic.Query.Relational.Predicates
{
    /// <summary>
    /// Implementation of the Not predicate. It is true if its operand is false
    /// </summary>
    [Serializable]
    public sealed class Not : UnaryPredicateBase, IEquatable<Not> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Predicates.Not"/> class.
        /// </summary>
        /// <param name='operand'>
        /// Operand.
        /// </param>
        public Not (Predicate operand): base(operand)
        {
        }

        /// <summary>
        /// Determines whether the specified <see cref="UnaryPredicateBase"/> is equal to the current <see cref="Predicates.Not"/>.
        /// </summary>
        /// <param name='other'>
        /// The <see cref="UnaryPredicateBase"/> to compare with the current <see cref="Predicates.Not"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="UnaryPredicateBase"/> is equal to the current
        /// <see cref="Predicates.Not"/>; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals (UnaryPredicateBase other)
        {
            return Equals (other as Not);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Predicates.Not"/> is equal to the current <see cref="Predicates.Not"/>.
        /// </summary>
        /// <param name='other'>
        /// The <see cref="Predicates.Not"/> to compare with the current <see cref="Predicates.Not"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Predicates.Not"/> is equal to the current
        /// <see cref="Predicates.Not"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Not other)
        {
            if (null == other) return false;
            return this.Operand.Equals (other.Operand);
        }

        /// <summary>
        /// Accept the specified visitor and context.
        /// </summary>
        /// <param name='visitor'>
        /// Visitor.
        /// </param>
        /// <param name='context'>
        /// Context.
        /// </param>
        /// <typeparam name='TResult'>
        /// The 1st type parameter.
        /// </typeparam>
        public override TResult Accept<TResult> (IVisitor<TResult> visitor, IVisitContext context)
        {
            return AcceptMe(this, visitor, context);
        }
    }
}


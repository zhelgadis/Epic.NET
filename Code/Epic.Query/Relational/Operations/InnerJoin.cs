//  
//  InnerJoin.cs
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
using Epic.Query.Relational.Predicates;


namespace Epic.Query.Relational.Operations
{
    /// <summary>
    /// This class models the Inner Join operation, which joins two relations and returns those
    /// record matching a given condition.
    /// </summary>
    [Serializable]
    public sealed class InnerJoin: Relation, IEquatable<InnerJoin>
    {
        private readonly Relation _leftRelation;
        private readonly Relation _rightRelation;
        private readonly Predicate _predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Epic.Query.Relational.Operations.InnerJoin"/> class.
        /// </summary>
        /// <param name='leftRelation'>
        /// Left relation.
        /// </param>
        /// <param name='rightRelation'>
        /// Right relation.
        /// </param>
        /// <param name='predicate'>
        /// Predicate used to join the two Relations.
        /// </param>
        public InnerJoin (Relation leftRelation, Relation rightRelation, Predicate predicate) :
            base(RelationType.InnerJoin, getDefaultName(leftRelation))
        {
            if (null == rightRelation)
                throw new ArgumentNullException("rightRelation");
            if (null == predicate)
                throw new ArgumentNullException("predicate");


            this._leftRelation = leftRelation;
            this._rightRelation = rightRelation;
            this._predicate = predicate;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Epic.Query.Relational.Operations.InnerJoin"/> class.
        /// </summary>
        /// <param name='leftRelation'>
        /// Left relation.
        /// </param>
        /// <param name='rightRelation'>
        /// Right relation.
        /// </param>
        /// <param name='predicate'>
        /// Predicate used to join the two Relations.
        /// </param>
        /// <param name='name'>
        /// Name assigned to the join relation.
        /// </param>
        public InnerJoin (Relation leftRelation, Relation rightRelation, Predicate predicate, string name):
            base(RelationType.InnerJoin, name)
        {
            if (null == leftRelation)
                throw new ArgumentNullException("leftRelation");
            if (null == rightRelation)
                throw new ArgumentNullException("rightRelation");
            if (null == predicate)
                throw new ArgumentNullException("predicate");
            if (null == name)
                throw new ArgumentNullException("name");

            this._leftRelation = leftRelation;
            this._rightRelation = rightRelation;
            this._predicate = predicate;
        }

        /// <summary>
        /// Gets the left relation.
        /// </summary>
        /// <value>
        /// The left relation.
        /// </value>
        public Relation LeftRelation { get { return this._leftRelation; } }

        /// <summary>
        /// Gets the right relation.
        /// </summary>
        /// <value>
        /// The right relation.
        /// </value>
        public Relation RightRelation { get { return this._rightRelation; } }

        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>
        /// The predicate.
        /// </value>
        public Predicate Predicate { get { return this._predicate; } }

        /// <summary>
        /// Determines whether the specified <see cref="Epic.Query.Relational.Relation"/> is equal to the current <see cref="Epic.Query.Relational.Operations.InnerJoin"/>.
        /// </summary>
        /// <param name='other'>
        /// The <see cref="Epic.Query.Relational.Relation"/> to compare with the current <see cref="Epic.Query.Relational.Operations.InnerJoin"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Epic.Query.Relational.Relation"/> is equal to the current
        /// <see cref="Epic.Query.Relational.Operations.InnerJoin"/>; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals (Relation other)
        {
            return Equals (other as InnerJoin);
        }

        /// <summary>
        /// Determines whether the specified <see cref="Epic.Query.Relational.Operations.InnerJoin"/> is equal to the
        /// current <see cref="Epic.Query.Relational.Operations.InnerJoin"/>.
        /// </summary>
        /// <param name='other'>
        /// The <see cref="Epic.Query.Relational.Operations.InnerJoin"/> to compare with the current <see cref="Epic.Query.Relational.Operations.InnerJoin"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="Epic.Query.Relational.Operations.InnerJoin"/> is equal to the
        /// current <see cref="Epic.Query.Relational.Operations.InnerJoin"/>; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals (InnerJoin other)
        {
            if (null == other) return false;

            return this.LeftRelation.Equals (other.LeftRelation) &&
                this.RightRelation.Equals (other.RightRelation) &&
                    this.Predicate.Equals (other.Predicate);
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="Epic.Query.Relational.Operations.InnerJoin"/> object.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.
        /// </returns>
        public override int GetHashCode ()
        {
            return this.LeftRelation.GetHashCode () ^ this.RightRelation.GetHashCode () ^
                this.Predicate.GetHashCode ();
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
            return AcceptMe (this, visitor, context);
        }

        private static string getDefaultName (Relation relation)
        {
            if (null == relation) 
                throw new ArgumentNullException("relation");

            return relation.Name; 
        }
    }
}


//  
//  ChangeEventArgsTester.cs
//  
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
// 
//  Copyright (c) 2010-2011 Giacomo Tesio
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
using NUnit.Framework;
using Challenge00.DDDSample.Shared;
namespace Contracts.Shared
{
	[TestFixture]
	public class ChangeEventArgsQA
	{
		[Test]
		public void Ctor_withValidInstances_works()
		{
			// arrange:
			object oldV = new object();
			object newV = new object();
		
			// act:
			ChangeEventArgs<object> args = new ChangeEventArgs<object>(oldV, newV);
		
			// assert:
			Assert.AreSame(oldV, args.OldValue);
			Assert.AreSame(newV, args.NewValue);
		}
		
		[Test]
		public void Ctor_withNullOldValue_works()
		{
			// arrange:
			object newV = new object();
		
			// act:
			ChangeEventArgs<object> args = new ChangeEventArgs<object>(null, newV);
		
			// assert:
			Assert.IsNull(args.OldValue);
			Assert.AreSame(newV, args.NewValue);
		}
		
		[Test]
		public void Ctor_withNullNewValue_works()
		{
			// arrange:
			object oldV = new object();
		
			// act:
			ChangeEventArgs<object> args = new ChangeEventArgs<object>(oldV, null);
		
			// assert:
			Assert.AreSame(oldV, args.OldValue);
			Assert.IsNull(args.NewValue);
		}
	}
}


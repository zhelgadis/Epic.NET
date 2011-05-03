//  
//  FakeApplication.cs
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
namespace Epic.Fakes
{
	public class FakeApplication : ApplicationBase
	{
		public FakeApplication(string name)
			: base(name)
		{
		}
		
		public FakeApplication(IEnvironment environment, IEnterprise enterprise)
			: base("Fake Application")
		{
			_environment = environment;
			_enterprise = enterprise;
		}

		
		private readonly IEnvironment _environment;
		public override IEnvironment Environment { get { return _environment; } }
	
		private readonly IEnterprise _enterprise;
		public override IEnterprise Enterprise { get { return _enterprise; } }
	}
}

//  
//  ClaimedCargoTester.cs
//  
//  Author:
//       Giacomo Tesio <giacomo@tesio.it>
// 
//  Copyright (c) 2010 Giacomo Tesio
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
using Challenge00.DDDSample.Cargo;
using Rhino.Mocks;
using Challenge00.DDDSample.Location;
using Challenge00.DDDSample.Voyage;
namespace DefaultImplementation.Cargo
{
	[TestFixture()]
	public class ClaimedCargoTester
	{
		[Test]
		public void Test_Claim_01()
		{
			// arrange:
			UnLocode final = new UnLocode("FINAL");
			TrackingId id = new TrackingId("CLAIM");
			IItinerary itinerary = MockRepository.GenerateStrictMock<IItinerary>();
			itinerary.Expect(i => i.FinalArrivalDate).Return(DateTime.UtcNow).Repeat.AtLeastOnce();
			itinerary.Expect(i => i.FinalArrivalLocation).Return(final).Repeat.AtLeastOnce();
			IRouteSpecification specification = MockRepository.GenerateStrictMock<IRouteSpecification>();
			specification.Expect(s => s.IsSatisfiedBy(itinerary)).Return(true).Repeat.Any();
			CargoState previousState = MockRepository.GenerateStrictMock<CargoState>(id, specification);
			previousState = MockRepository.GenerateStrictMock<CargoState>(previousState, itinerary);
			previousState.Expect(s => s.IsUnloadedAtDestination).Return(true).Repeat.AtLeastOnce();
			previousState.Expect(s => s.TransportStatus).Return(TransportStatus.InPort).Repeat.AtLeastOnce();
			DateTime claimDate = DateTime.UtcNow;
			
		
			// act:
			ClaimedCargo state = new ClaimedCargo(previousState, claimDate);
		
			// assert:
			Assert.AreEqual(TransportStatus.Claimed, state.TransportStatus);
			Assert.AreEqual(RoutingStatus.Routed, state.RoutingStatus);
			Assert.AreSame(final, state.LastKnownLocation);
			Assert.AreSame(specification, state.RouteSpecification);
			Assert.IsNull(state.CurrentVoyage);
			Assert.IsTrue(state.IsUnloadedAtDestination);
			itinerary.VerifyAllExpectations();
			specification.VerifyAllExpectations();
		}
		
		[Test]
		public void Test_StateTransitions_01()
		{
			// arrange:
			UnLocode final = new UnLocode("FINAL");
			TrackingId id = new TrackingId("CLAIM");
			ILocation finalLocation = MockRepository.GenerateStrictMock<ILocation>();
			finalLocation.Expect(l => l.UnLocode).Return(final).Repeat.AtLeastOnce();
			ILocation otherLocation = MockRepository.GenerateStrictMock<ILocation>();
			otherLocation.Expect(l => l.UnLocode).Return(new UnLocode("OTHER")).Repeat.AtLeastOnce();
			IItinerary itinerary = MockRepository.GenerateStrictMock<IItinerary>();
			itinerary.Expect(i => i.FinalArrivalDate).Return(DateTime.UtcNow).Repeat.Any();
			itinerary.Expect(i => i.FinalArrivalLocation).Return(final).Repeat.Any();
			IRouteSpecification specification = MockRepository.GenerateStrictMock<IRouteSpecification>();
			specification.Expect(s => s.IsSatisfiedBy(itinerary)).Return(true).Repeat.Any();
			CargoState previousState = MockRepository.GenerateStrictMock<CargoState>(id, specification);
			previousState = MockRepository.GenerateStrictMock<CargoState>(previousState, itinerary);
			previousState.Expect(s => s.IsUnloadedAtDestination).Return(true).Repeat.Any();
			previousState.Expect(s => s.TransportStatus).Return(TransportStatus.InPort).Repeat.Any();
			IVoyage voyage = MockRepository.GenerateStrictMock<IVoyage>();
			DateTime claimDate = DateTime.UtcNow;
			
			ClaimedCargo state = new ClaimedCargo(previousState, claimDate);
			
			// act:
			CargoState newState = state.Claim(finalLocation, claimDate);
		
			// assert:
			Assert.AreSame(state, newState);
			Assert.Throws<ArgumentNullException>(delegate { state.Claim(null, DateTime.UtcNow); });
			Assert.Throws<InvalidOperationException>(delegate { state.Claim(finalLocation, DateTime.UtcNow); });
			Assert.Throws<InvalidOperationException>(delegate { state.Claim(otherLocation, claimDate); });
			Assert.Throws<InvalidOperationException>(delegate { state.LoadOn(voyage, DateTime.UtcNow); });
			Assert.Throws<InvalidOperationException>(delegate { state.Unload(voyage, DateTime.UtcNow); });
			Assert.Throws<InvalidOperationException>(delegate { state.SpecifyNewRoute(MockRepository.GenerateStrictMock<IRouteSpecification>()); });
			Assert.Throws<InvalidOperationException>(delegate { state.AssignToRoute(MockRepository.GenerateStrictMock<IItinerary>()); });
			Assert.Throws<InvalidOperationException>(delegate { state.Recieve(MockRepository.GenerateStrictMock<ILocation>(), DateTime.UtcNow); });
			Assert.Throws<InvalidOperationException>(delegate { state.ClearCustoms(MockRepository.GenerateStrictMock<ILocation>(), DateTime.UtcNow); });
			itinerary.VerifyAllExpectations();
			specification.VerifyAllExpectations();
		}
		
	}
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    internal class FuelTruck : Truck
    {
        internal static Dictionary<string, Action<Vehicle, string>> s_ListOfQuestionsAndValidations;

        internal FuelTruck()
        {
            if (s_ListOfQuestionsAndValidations == null)
            {
                s_ListOfQuestionsAndValidations = this.CreateAllQuestionsAndValidations();
            }

            this.Energy = new FuelEnergy(120f, FuelEnergy.eFuelType.Soler);
        }

        internal override Dictionary<string, Action<Vehicle, string>> GetAllQuestionsAndValidations()
        {
            return FuelTruck.s_ListOfQuestionsAndValidations;
        }

        private Dictionary<string, Action<Vehicle, string>> CreateAllQuestionsAndValidations()
        {
            Dictionary<string, Action<Vehicle, string>> questionsAndValidations = new Dictionary<string, Action<Vehicle, string>>();
            foreach (KeyValuePair<string, Action<Vehicle, string>> pair in Vehicle.InstantiationVehicleQueriesAndValidations)
            {
                questionsAndValidations[pair.Key] = pair.Value;
            }

            foreach (KeyValuePair<string, Action<Vehicle, string>> pair in Wheel.InstantiationWheelQueriesAndValidations)
            {
                questionsAndValidations[pair.Key] = pair.Value;
            }

            foreach (KeyValuePair<string, Action<Vehicle, string>> pair in Truck.InstantiationTruckQueriesAndValidations)
            {
                questionsAndValidations[pair.Key] = pair.Value;
            }

            foreach (KeyValuePair<string, Action<Vehicle, string>> pair in FuelEnergy.InstantiationFuelEnergyQueriesAndValidations)
            {
                questionsAndValidations[pair.Key] = pair.Value;
            }

            return questionsAndValidations;
        }
    }
}

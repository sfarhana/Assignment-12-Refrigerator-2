using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefrigeratorAppPractice3
{
    class Refrigerator
    {
        private double maximumWeight;
        private double currentWeight;
        private double remainingWeight;

        public double MaxWeight
        {
            set
            {
                this.maximumWeight = value;
            }
            get
            {
                return this.maximumWeight;
            }
        }
        public double CurrentWeight
        {
            set
            {
                this.currentWeight = value;
            }
            get
            {
                return this.currentWeight;
            }
        }

        public void CalculateWeight(int item,double weight)
        {
            CurrentWeight += (item * weight);
            
        }

        public double RemainingWeight
        {
            get
            {
                return this.remainingWeight=this.maximumWeight - this.currentWeight; 
            }
        }
        
    }
}

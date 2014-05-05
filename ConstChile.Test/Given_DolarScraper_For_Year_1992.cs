﻿using ConstChile.Indicators;
using ConstChile.Sii;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ConstChile.Test
{
    public class Given_DolarScraper_For_Year_1992
    {
        private DolarScraper scraper;

        [SetUp]
        public void CreateScraper()
        {
            scraper = new DolarScraper(1992);
        }
        
        [Test]
        public void Extract_returns_249_indicators()
        {
            scraper.Extract();
            Assert.AreEqual(249, scraper.Dolars.Count);
        }

        [Test]
        public void 
            Extract_returns_exact_entries()
        {
            Dolar[] expectedDollars =
                {
                #region Year 2013 indicators 
                  new Dolar() { Date = new DateTime(1992,4,1), Value = 348.02m},new Dolar() { Date = new DateTime(1992,6,1), Value = 351.99m},new Dolar() { Date = new DateTime(1992,7,1), Value = 358.71m},new Dolar() { Date = new DateTime(1992,9,1), Value = 374.80m},new Dolar() { Date = new DateTime(1992,10,1), Value = 375.31m},new Dolar() { Date = new DateTime(1992,12,1), Value = 381.70m},new Dolar() { Date = new DateTime(1992,1,2), Value = 374.51m},new Dolar() { Date = new DateTime(1992,3,2), Value = 346.69m},new Dolar() { Date = new DateTime(1992,4,2), Value = 347.19m},new Dolar() { Date = new DateTime(1992,6,2), Value = 352.61m},new Dolar() { Date = new DateTime(1992,7,2), Value = 356.91m},new Dolar() { Date = new DateTime(1992,9,2), Value = 375.97m},new Dolar() { Date = new DateTime(1992,10,2), Value = 374.86m},new Dolar() { Date = new DateTime(1992,11,2), Value = 373.99m},new Dolar() { Date = new DateTime(1992,12,2), Value = 381.34m},new Dolar() { Date = new DateTime(1992,1,3), Value = 374.10m},new Dolar() { Date = new DateTime(1992,2,3), Value = 350.46m},new Dolar() { Date = new DateTime(1992,3,3), Value = 346.51m},new Dolar() { Date = new DateTime(1992,4,3), Value = 347.50m},new Dolar() { Date = new DateTime(1992,6,3), Value = 350.56m},new Dolar() { Date = new DateTime(1992,7,3), Value = 356.15m},new Dolar() { Date = new DateTime(1992,8,3), Value = 364.67m},new Dolar() { Date = new DateTime(1992,9,3), Value = 377.08m},new Dolar() { Date = new DateTime(1992,11,3), Value = 372.72m},new Dolar() { Date = new DateTime(1992,12,3), Value = 380.84m},new Dolar() { Date = new DateTime(1992,2,4), Value = 347.26m},new Dolar() { Date = new DateTime(1992,3,4), Value = 345.96m},new Dolar() { Date = new DateTime(1992,5,4), Value = 346.69m},new Dolar() { Date = new DateTime(1992,6,4), Value = 351.64m},new Dolar() { Date = new DateTime(1992,8,4), Value = 364.98m},new Dolar() { Date = new DateTime(1992,9,4), Value = 375.62m},new Dolar() { Date = new DateTime(1992,11,4), Value = 374.12m},new Dolar() { Date = new DateTime(1992,12,4), Value = 380.84m},new Dolar() { Date = new DateTime(1992,2,5), Value = 348.33m},new Dolar() { Date = new DateTime(1992,3,5), Value = 344.81m},new Dolar() { Date = new DateTime(1992,5,5), Value = 346.57m},new Dolar() { Date = new DateTime(1992,6,5), Value = 351.79m},new Dolar() { Date = new DateTime(1992,8,5), Value = 366.68m},new Dolar() { Date = new DateTime(1992,10,5), Value = 374.51m},new Dolar() { Date = new DateTime(1992,11,5), Value = 374.16m},new Dolar() { Date = new DateTime(1992,1,6), Value = 374.14m},new Dolar() { Date = new DateTime(1992,2,6), Value = 349.93m},new Dolar() { Date = new DateTime(1992,3,6), Value = 344.41m},new Dolar() { Date = new DateTime(1992,4,6), Value = 347.24m},new Dolar() { Date = new DateTime(1992,5,6), Value = 346.53m},new Dolar() { Date = new DateTime(1992,7,6), Value = 356.07m},new Dolar() { Date = new DateTime(1992,8,6), Value = 367.99m},new Dolar() { Date = new DateTime(1992,10,6), Value = 374.23m},new Dolar() { Date = new DateTime(1992,11,6), Value = 375.13m},new Dolar() { Date = new DateTime(1992,1,7), Value = 374.07m},new Dolar() { Date = new DateTime(1992,2,7), Value = 350.39m},new Dolar() { Date = new DateTime(1992,4,7), Value = 347.16m},new Dolar() { Date = new DateTime(1992,5,7), Value = 346.31m},new Dolar() { Date = new DateTime(1992,7,7), Value = 357.39m},new Dolar() { Date = new DateTime(1992,8,7), Value = 367.68m},new Dolar() { Date = new DateTime(1992,9,7), Value = 376.33m},new Dolar() { Date = new DateTime(1992,10,7), Value = 373.83m},new Dolar() { Date = new DateTime(1992,12,7), Value = 381.31m},new Dolar() { Date = new DateTime(1992,1,8), Value = 374.04m},new Dolar() { Date = new DateTime(1992,4,8), Value = 346.76m},new Dolar() { Date = new DateTime(1992,5,8), Value = 345.60m},new Dolar() { Date = new DateTime(1992,6,8), Value = 352.95m},new Dolar() { Date = new DateTime(1992,7,8), Value = 358.62m},new Dolar() { Date = new DateTime(1992,9,8), Value = 376.49m},new Dolar() { Date = new DateTime(1992,10,8), Value = 371.50m},new Dolar() { Date = new DateTime(1992,1,9), Value = 374.06m},new Dolar() { Date = new DateTime(1992,3,9), Value = 344.48m},new Dolar() { Date = new DateTime(1992,4,9), Value = 346.26m},new Dolar() { Date = new DateTime(1992,6,9), Value = 353.22m},new Dolar() { Date = new DateTime(1992,7,9), Value = 359.68m},new Dolar() { Date = new DateTime(1992,9,9), Value = 376.46m},new Dolar() { Date = new DateTime(1992,10,9), Value = 370.40m},new Dolar() { Date = new DateTime(1992,11,9), Value = 376.00m},new Dolar() { Date = new DateTime(1992,12,9), Value = 381.57m},new Dolar() { Date = new DateTime(1992,1,10), Value = 374.09m},new Dolar() { Date = new DateTime(1992,2,10), Value = 349.82m},new Dolar() { Date = new DateTime(1992,3,10), Value = 345.03m},new Dolar() { Date = new DateTime(1992,4,10), Value = 346.21m},new Dolar() { Date = new DateTime(1992,6,10), Value = 353.41m},new Dolar() { Date = new DateTime(1992,7,10), Value = 360.87m},new Dolar() { Date = new DateTime(1992,8,10), Value = 366.09m},new Dolar() { Date = new DateTime(1992,9,10), Value = 375.51m},new Dolar() { Date = new DateTime(1992,11,10), Value = 376.83m},new Dolar() { Date = new DateTime(1992,12,10), Value = 381.37m},new Dolar() { Date = new DateTime(1992,2,11), Value = 347.65m},new Dolar() { Date = new DateTime(1992,3,11), Value = 345.84m},new Dolar() { Date = new DateTime(1992,5,11), Value = 345.40m},new Dolar() { Date = new DateTime(1992,6,11), Value = 353.89m},new Dolar() { Date = new DateTime(1992,8,11), Value = 366.28m},new Dolar() { Date = new DateTime(1992,11,11), Value = 376.35m},new Dolar() { Date = new DateTime(1992,12,11), Value = 380.57m},new Dolar() { Date = new DateTime(1992,2,12), Value = 347.14m},new Dolar() { Date = new DateTime(1992,3,12), Value = 347.70m},new Dolar() { Date = new DateTime(1992,5,12), Value = 346.24m},new Dolar() { Date = new DateTime(1992,6,12), Value = 353.83m},new Dolar() { Date = new DateTime(1992,8,12), Value = 367.07m},new Dolar() { Date = new DateTime(1992,11,12), Value = 376.54m},new Dolar() { Date = new DateTime(1992,1,13), Value = 374.49m},new Dolar() { Date = new DateTime(1992,2,13), Value = 347.30m},new Dolar() { Date = new DateTime(1992,3,13), Value = 348.40m},new Dolar() { Date = new DateTime(1992,4,13), Value = 345.30m},new Dolar() { Date = new DateTime(1992,5,13), Value = 346.02m},new Dolar() { Date = new DateTime(1992,7,13), Value = 360.53m},new Dolar() { Date = new DateTime(1992,8,13), Value = 367.00m},new Dolar() { Date = new DateTime(1992,10,13), Value = 371.12m},new Dolar() { Date = new DateTime(1992,11,13), Value = 376.74m},new Dolar() { Date = new DateTime(1992,1,14), Value = 374.60m},new Dolar() { Date = new DateTime(1992,2,14), Value = 347.51m},new Dolar() { Date = new DateTime(1992,4,14), Value = 344.06m},new Dolar() { Date = new DateTime(1992,5,14), Value = 345.63m},new Dolar() { Date = new DateTime(1992,7,14), Value = 360.00m},new Dolar() { Date = new DateTime(1992,8,14), Value = 367.41m},new Dolar() { Date = new DateTime(1992,9,14), Value = 374.50m},new Dolar() { Date = new DateTime(1992,10,14), Value = 371.25m},new Dolar() { Date = new DateTime(1992,12,14), Value = 379.41m},new Dolar() { Date = new DateTime(1992,1,15), Value = 374.73m},new Dolar() { Date = new DateTime(1992,4,15), Value = 343.93m},new Dolar() { Date = new DateTime(1992,5,15), Value = 345.61m},new Dolar() { Date = new DateTime(1992,6,15), Value = 353.74m},new Dolar() { Date = new DateTime(1992,7,15), Value = 359.74m},new Dolar() { Date = new DateTime(1992,9,15), Value = 375.45m},new Dolar() { Date = new DateTime(1992,10,15), Value = 371.84m},new Dolar() { Date = new DateTime(1992,12,15), Value = 377.33m},new Dolar() { Date = new DateTime(1992,1,16), Value = 374.85m},new Dolar() { Date = new DateTime(1992,3,16), Value = 347.40m},new Dolar() { Date = new DateTime(1992,4,16), Value = 344.62m},new Dolar() { Date = new DateTime(1992,6,16), Value = 354.97m},new Dolar() { Date = new DateTime(1992,7,16), Value = 360.43m},new Dolar() { Date = new DateTime(1992,9,16), Value = 374.27m},new Dolar() { Date = new DateTime(1992,10,16), Value = 371.17m},new Dolar() { Date = new DateTime(1992,11,16), Value = 377.40m},new Dolar() { Date = new DateTime(1992,12,16), Value = 377.45m},new Dolar() { Date = new DateTime(1992,1,17), Value = 374.93m},new Dolar() { Date = new DateTime(1992,2,17), Value = 347.57m},new Dolar() { Date = new DateTime(1992,3,17), Value = 348.23m},new Dolar() { Date = new DateTime(1992,6,17), Value = 355.76m},new Dolar() { Date = new DateTime(1992,7,17), Value = 361.18m},new Dolar() { Date = new DateTime(1992,8,17), Value = 367.35m},new Dolar() { Date = new DateTime(1992,9,17), Value = 374.10m},new Dolar() { Date = new DateTime(1992,11,17), Value = 378.57m},new Dolar() { Date = new DateTime(1992,12,17), Value = 377.39m},new Dolar() { Date = new DateTime(1992,2,18), Value = 346.70m},new Dolar() { Date = new DateTime(1992,3,18), Value = 347.81m},new Dolar() { Date = new DateTime(1992,5,18), Value = 346.28m},new Dolar() { Date = new DateTime(1992,8,18), Value = 367.63m},new Dolar() { Date = new DateTime(1992,11,18), Value = 379.51m},new Dolar() { Date = new DateTime(1992,12,18), Value = 378.20m},new Dolar() { Date = new DateTime(1992,2,19), Value = 346.19m},new Dolar() { Date = new DateTime(1992,3,19), Value = 349.27m},new Dolar() { Date = new DateTime(1992,5,19), Value = 346.74m},new Dolar() { Date = new DateTime(1992,6,19), Value = 355.88m},new Dolar() { Date = new DateTime(1992,8,19), Value = 367.81m},new Dolar() { Date = new DateTime(1992,10,19), Value = 372.04m},new Dolar() { Date = new DateTime(1992,11,19), Value = 379.03m},new Dolar() { Date = new DateTime(1992,1,20), Value = 375.42m},new Dolar() { Date = new DateTime(1992,2,20), Value = 346.81m},new Dolar() { Date = new DateTime(1992,3,20), Value = 353.84m},new Dolar() { Date = new DateTime(1992,4,20), Value = 345.43m},new Dolar() { Date = new DateTime(1992,5,20), Value = 347.05m},new Dolar() { Date = new DateTime(1992,7,20), Value = 361.84m},new Dolar() { Date = new DateTime(1992,8,20), Value = 368.00m},new Dolar() { Date = new DateTime(1992,10,20), Value = 372.65m},new Dolar() { Date = new DateTime(1992,11,20), Value = 378.94m},new Dolar() { Date = new DateTime(1992,1,21), Value = 375.51m},new Dolar() { Date = new DateTime(1992,2,21), Value = 346.13m},new Dolar() { Date = new DateTime(1992,4,21), Value = 346.06m},new Dolar() { Date = new DateTime(1992,7,21), Value = 361.89m},new Dolar() { Date = new DateTime(1992,8,21), Value = 369.79m},new Dolar() { Date = new DateTime(1992,9,21), Value = 376.01m},new Dolar() { Date = new DateTime(1992,10,21), Value = 374.28m},new Dolar() { Date = new DateTime(1992,12,21), Value = 379.87m},new Dolar() { Date = new DateTime(1992,1,22), Value = 375.64m},new Dolar() { Date = new DateTime(1992,5,22), Value = 346.85m},new Dolar() { Date = new DateTime(1992,6,22), Value = 357.11m},new Dolar() { Date = new DateTime(1992,7,22), Value = 362.56m},new Dolar() { Date = new DateTime(1992,9,22), Value = 376.50m},new Dolar() { Date = new DateTime(1992,10,22), Value = 375.33m},new Dolar() { Date = new DateTime(1992,12,22), Value = 379.59m},new Dolar() { Date = new DateTime(1992,1,23), Value = 375.76m},new Dolar() { Date = new DateTime(1992,3,23), Value = 352.03m},new Dolar() { Date = new DateTime(1992,4,23), Value = 346.48m},new Dolar() { Date = new DateTime(1992,6,23), Value = 357.96m},new Dolar() { Date = new DateTime(1992,7,23), Value = 363.66m},new Dolar() { Date = new DateTime(1992,9,23), Value = 377.13m},new Dolar() { Date = new DateTime(1992,10,23), Value = 372.75m},new Dolar() { Date = new DateTime(1992,11,23), Value = 379.45m},new Dolar() { Date = new DateTime(1992,12,23), Value = 380.04m},new Dolar() { Date = new DateTime(1992,1,24), Value = 358.07m},new Dolar() { Date = new DateTime(1992,2,24), Value = 346.08m},new Dolar() { Date = new DateTime(1992,3,24), Value = 350.56m},new Dolar() { Date = new DateTime(1992,4,24), Value = 346.69m},new Dolar() { Date = new DateTime(1992,6,24), Value = 359.71m},new Dolar() { Date = new DateTime(1992,7,24), Value = 365.51m},new Dolar() { Date = new DateTime(1992,8,24), Value = 372.44m},new Dolar() { Date = new DateTime(1992,9,24), Value = 377.27m},new Dolar() { Date = new DateTime(1992,11,24), Value = 380.67m},new Dolar() { Date = new DateTime(1992,12,24), Value = 380.36m},new Dolar() { Date = new DateTime(1992,2,25), Value = 347.50m},new Dolar() { Date = new DateTime(1992,3,25), Value = 350.76m},new Dolar() { Date = new DateTime(1992,5,25), Value = 346.87m},new Dolar() { Date = new DateTime(1992,6,25), Value = 359.97m},new Dolar() { Date = new DateTime(1992,8,25), Value = 371.75m},new Dolar() { Date = new DateTime(1992,9,25), Value = 377.27m},new Dolar() { Date = new DateTime(1992,11,25), Value = 381.20m},new Dolar() { Date = new DateTime(1992,2,26), Value = 348.66m},new Dolar() { Date = new DateTime(1992,3,26), Value = 351.70m},new Dolar() { Date = new DateTime(1992,5,26), Value = 347.19m},new Dolar() { Date = new DateTime(1992,6,26), Value = 359.07m},new Dolar() { Date = new DateTime(1992,8,26), Value = 372.43m},new Dolar() { Date = new DateTime(1992,10,26), Value = 373.46m},new Dolar() { Date = new DateTime(1992,11,26), Value = 380.84m},new Dolar() { Date = new DateTime(1992,1,27), Value = 359.73m},new Dolar() { Date = new DateTime(1992,2,27), Value = 348.54m},new Dolar() { Date = new DateTime(1992,3,27), Value = 351.94m},new Dolar() { Date = new DateTime(1992,4,27), Value = 346.91m},new Dolar() { Date = new DateTime(1992,5,27), Value = 347.70m},new Dolar() { Date = new DateTime(1992,7,27), Value = 366.80m},new Dolar() { Date = new DateTime(1992,8,27), Value = 374.35m},new Dolar() { Date = new DateTime(1992,10,27), Value = 373.97m},new Dolar() { Date = new DateTime(1992,11,27), Value = 380.78m},new Dolar() { Date = new DateTime(1992,1,28), Value = 356.18m},new Dolar() { Date = new DateTime(1992,2,28), Value = 347.30m},new Dolar() { Date = new DateTime(1992,4,28), Value = 346.56m},new Dolar() { Date = new DateTime(1992,5,28), Value = 347.73m},new Dolar() { Date = new DateTime(1992,7,28), Value = 366.73m},new Dolar() { Date = new DateTime(1992,8,28), Value = 374.36m},new Dolar() { Date = new DateTime(1992,9,28), Value = 377.39m},new Dolar() { Date = new DateTime(1992,10,28), Value = 373.91m},new Dolar() { Date = new DateTime(1992,12,28), Value = 380.89m},new Dolar() { Date = new DateTime(1992,1,29), Value = 356.29m},new Dolar() { Date = new DateTime(1992,4,29), Value = 346.85m},new Dolar() { Date = new DateTime(1992,5,29), Value = 347.69m},new Dolar() { Date = new DateTime(1992,7,29), Value = 365.14m},new Dolar() { Date = new DateTime(1992,9,29), Value = 376.65m},new Dolar() { Date = new DateTime(1992,10,29), Value = 373.34m},new Dolar() { Date = new DateTime(1992,12,29), Value = 381.95m},new Dolar() { Date = new DateTime(1992,1,30), Value = 355.51m},new Dolar() { Date = new DateTime(1992,3,30), Value = 350.67m},new Dolar() { Date = new DateTime(1992,4,30), Value = 346.78m},new Dolar() { Date = new DateTime(1992,6,30), Value = 359.88m},new Dolar() { Date = new DateTime(1992,7,30), Value = 364.12m},new Dolar() { Date = new DateTime(1992,9,30), Value = 375.92m},new Dolar() { Date = new DateTime(1992,10,30), Value = 373.38m},new Dolar() { Date = new DateTime(1992,11,30), Value = 381.30m},new Dolar() { Date = new DateTime(1992,12,30), Value = 382.33m},new Dolar() { Date = new DateTime(1992,1,31), Value = 353.80m},new Dolar() { Date = new DateTime(1992,3,31), Value = 349.53m},new Dolar() { Date = new DateTime(1992,7,31), Value = 364.17m},new Dolar() { Date = new DateTime(1992,8,31), Value = 374.40m},
                };

                #endregion
            List<Dolar> dolars = new List<Dolar>(366);
            dolars.AddRange(expectedDollars);
            scraper.Extract();
            Assert.That(scraper.Dolars, Is.EquivalentTo(dolars));
        }
    }
}
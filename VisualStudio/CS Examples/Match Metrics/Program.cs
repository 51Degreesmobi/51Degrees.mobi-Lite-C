﻿/**
 * This Source Code Form is copyright of 51Degrees Mobile Experts Limited.
 * Copyright (c) 2015 51Degrees Mobile Experts Limited, 5 Charlotte Close,
 * Caversham, Reading, Berkshire, United Kingdom RG4 7BY
 * 
 * This Source Code Form is the subject of the following patent
 * applications, owned by 51Degrees Mobile Experts Limited of 5 Charlotte
 * Close, Caversham, Reading, Berkshire, United Kingdom RG4 7BY:
 * European Patent Application No. 13192291.6; and
 * United States Patent Application Nos. 14/085,223 and 14/085,301.
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0.
 * 
 * If a copy of the MPL was not distributed with this file, You can obtain
 * one at http://mozilla.org/MPL/2.0/.
 * 
 * This Source Code Form is "Incompatible With Secondary Licenses", as
 * defined by the Mozilla Public License, v. 2.0.
 */

/*
<tutorial>
Match metrics example of using 51Degrees device detection. 
The example shows how to:
<ol>
<li>Set the various settings for the 51Degrees detector
<p><code>
string fileName = args[0];
</code></p>
<li>Instantiate the 51Degrees device detection provider
with these settings
<p><code>
Provider provider = new Provider(FileName, properties);
</code></p>
<li>Produce a match for a single HTTP User-Agent
<p><code>
match = provider.getMatch(userAgent);
</code></p>
<li>Obtain device Id: consists of four components separated by a hyphen 
symbol: Hardware-Platform-Browser-IsCrawler where each Component 
represents an ID of the corresponding Profile.
<p><code>
deviceId = match.DeviceId;
</code></p>
<li>Obtain match method: provides information about the 
algorithm that was used to perform detection for a particular User-Agent. 
For more information on what each method means please see: 
<a href="https://51degrees.com/support/documentation/pattern">
How device detection works</a>
<p><code>method = match.Method;</code></p>
<li>Obtain difference:  used when detection method is not Exact or None. 
This is an integer value and the larger the value the less confident the 
detector is in this result.
<p><code>difference = match.Difference;</code></p>
<li>Obtain signature rank: an integer value that indicates how popular 
the device is. The lower the rank the more popular the signature.
<p><code>rank =  match.Rank;</code></p>
</ol>
This tutorial assumes you are building this from within the
51Degrees Visual Studio solution.  Additionaly, when running,
the location of a 51Degrees data file must be passed as a 
command line argument if you wish to use premium or enterprise
</tutorial>
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiftyOne.Mobile.Detection.Provider.Interop.Pattern;

namespace FiftyOne.Example.Illustration.CSharp.MatchMetrics
{
    public class Program
    {
        // Snippet Start
        /// <summary>
        /// Performs the various assert tests.
        /// </summary>
        /// <param name="match"></param>
        public static void validateMatchMetrics(Match match)
        {
            // EXACT and NONE method.
            if (match.Method == 1 || match.Method == 0)
            {
                Assert.IsTrue(match.Difference == 0);
            }
            // NUMERIC, NEAREST or CLOSEST
            else
            {
                Assert.IsTrue(match.Difference > 0);
            }
            Assert.IsTrue(match.Rank >= 0);
        }

        /// <summary>
        /// Prints match metrics associated with a given match object.
        /// </summary>
        /// <param name="match">a Match object</param>
        public static void OutputMatchMetrics(Match match)
        {
            Console.WriteLine("   Device Id: " + match.DeviceId);
            Console.WriteLine("   Method: " + match.Method);
            Console.WriteLine("   Difference: " + match.Difference);
            Console.WriteLine("   Rank: " + match.Rank);
        }
        public static void Run(string fileName)
        {
            Match match;

            // User-Agent string of an iPhone mobile device.
            string mobileUserAgent = ("Mozilla/5.0 (iPhone; CPU iPhone " +
                "OS 7_1 like Mac OS X) AppleWebKit/537.51.2 (KHTML, like " +
                "Gecko) 'Version/7.0 Mobile/11D167 Safari/9537.53");

            // User-Agent string of Firefox Web browser version 41 on dektop.
            string desktopUserAgent = ("Mozilla/5.0 (Windows NT 6.3; " +
                "WOW64; rv:41.0) Gecko/20100101 Firefox/41.0");

            // User-Agent string of a MediaHub device.
            string mediaHubUserAgent = ("Mozilla/5.0 (Linux; Android " +
                "4.4.2; X7 Quad Core Build/KOT49H) AppleWebKit/537.36 " +
                "(KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 " +
                "Safari/537.36");

            /**
            * Initialises the device detection dataset with the above settings.
            * This uses the Lite data file For more info
            * see:
            * <a href="https://51degrees.com/compare-data-options">compare data options
            * </a>
            */
            Provider provider = new Provider(fileName);

            Console.WriteLine("Starting Match Metrics Example.");

            // Carries out a match for a mobile User-Agent.
            Console.WriteLine("\nMobile User-Agent: " + mobileUserAgent);
            match = provider.getMatch(mobileUserAgent);
            validateMatchMetrics(match);
            OutputMatchMetrics(match);
            // Each match retrieves a workset from the pool, it is important 
            // to return the workset back into the pool by using Dispose().
            match.Dispose();

            // Carries out a match for a desktop User-Agent.
            Console.WriteLine("\nDesktop User-Agent: " + desktopUserAgent);
            match = provider.getMatch(desktopUserAgent);
            validateMatchMetrics(match);
            OutputMatchMetrics(match);
            // Each match retrieves a workset from the pool, it is important 
            // to return the workset back into the pool by using Dispose().
            match.Dispose();

            // Carries out a match for a MediaHub User-Agent.
            Console.WriteLine("\nMediaHub User-Agent: " + mediaHubUserAgent);
            match = provider.getMatch(mediaHubUserAgent);
            validateMatchMetrics(match);
            OutputMatchMetrics(match);
            // Each match retrieves a workset from the pool, it is important 
            // to return the workset back into the pool by using Dispose().
            match.Dispose();
            provider.Dispose();
        }
        // Snippet End

        static void Main(string[] args)
        {
            string fileName = args.Length > 0 ? args[0] : "../../../../../../data/51Degrees-LiteV3.2.dat";
            Run(fileName);

            // Waits for a character to be pressed.
            Console.ReadKey();
        }
    }
}

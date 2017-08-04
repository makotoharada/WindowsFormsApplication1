﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] patterns = new string[] {
"(0): smpte              - SMPTE 100% color bars   ",
"(1): snow               - Random (television snow)",
"(2): black              - 100% Black              ",
"(3): white              - 100% White              ",
"(4): red                - Red                     ",
"(5): green              - Green                   ",
"(6): blue               - Blue                    ",
"(7): checkers-1         - Checkers 1px            ",
"(8): checkers-2         - Checkers 2px            ",
"(9): checkers-4         - Checkers 4px            ",
"(10): checkers-8        - Checkers 8px            ",
"(11): circular          - Circular                ",
"(12): blink             - Blink                   ",
"(13): smpte75           - SMPTE 75% color bars    ",
"(14): zone-plate        - Zone plate              ",
"(15): gamut             - Gamut checkers          ",
"(16): chroma-zone-plate - Chroma zone plate       ",
"(17): solid-color       - Solid color             ",
"(18): ball              - Moving ball             ",
"(19): smpte100          - SMPTE 100% color bars   ",
"(20): bar               - Bar                     ",
"(21): pinwheel          - Pinwheel                ",
"(22): spokes            - Spokes                  "
};

            foreach (string pattern in patterns)
            {
                Console.WriteLine(pattern);
            }

        }
    }
}

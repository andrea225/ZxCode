﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace ZxDxf
{
    public class AciColor
    {
        private static readonly IReadOnlyDictionary<int, int[]> AciColors = new Dictionary<int, int[]>
        {
            {1, new int[] {255, 0, 0}},
            {2, new int[] {255, 255, 0}},
            {3, new int[] {0, 255, 0}},
            {4, new int[] {0, 255, 255}},
            {5, new int[] {0, 0, 255}},
            {6, new int[] {255, 0, 255}},
            {7, new int[] {255, 255, 255}},
            {8, new int[] {128, 128, 128}},
            {9, new int[] {192, 192, 192}},
            {10, new int[] {255, 0, 0}},
            {11, new int[] {255, 127, 127}},
            {12, new int[] {165, 0, 0}},
            {13, new int[] {165, 82, 82}},
            {14, new int[] {127, 0, 0}},
            {15, new int[] {127, 63, 63}},
            {16, new int[] {76, 0, 0}},
            {17, new int[] {76, 38, 38}},
            {18, new int[] {38, 0, 0}},
            {19, new int[] {38, 19, 19}},
            {20, new int[] {255, 63, 0}},
            {21, new int[] {255, 159, 127}},
            {22, new int[] {165, 41, 0}},
            {23, new int[] {165, 103, 82}},
            {24, new int[] {127, 31, 0}},
            {25, new int[] {127, 79, 63}},
            {26, new int[] {76, 19, 0}},
            {27, new int[] {76, 47, 38}},
            {28, new int[] {38, 9, 0}},
            {29, new int[] {38, 28, 19}},
            {30, new int[] {255, 127, 0}},
            {31, new int[] {255, 191, 127}},
            {32, new int[] {165, 82, 0}},
            {33, new int[] {165, 124, 82}},
            {34, new int[] {127, 63, 0}},
            {35, new int[] {127, 95, 63}},
            {36, new int[] {76, 38, 0}},
            {37, new int[] {76, 57, 38}},
            {38, new int[] {38, 19, 0}},
            {39, new int[] {38, 28, 19}},
            {40, new int[] {255, 191, 0}},
            {41, new int[] {255, 223, 127}},
            {42, new int[] {165, 124, 0}},
            {43, new int[] {165, 145, 82}},
            {44, new int[] {127, 95, 0}},
            {45, new int[] {127, 111, 63}},
            {46, new int[] {76, 57, 0}},
            {47, new int[] {76, 66, 38}},
            {48, new int[] {38, 28, 0}},
            {49, new int[] {38, 33, 19}},
            {50, new int[] {255, 255, 0}},
            {51, new int[] {255, 255, 127}},
            {52, new int[] {165, 165, 0}},
            {53, new int[] {165, 165, 82}},
            {54, new int[] {127, 127, 0}},
            {55, new int[] {127, 127, 63}},
            {56, new int[] {76, 76, 0}},
            {57, new int[] {76, 76, 38}},
            {58, new int[] {38, 38, 0}},
            {59, new int[] {38, 38, 19}},
            {60, new int[] {191, 255, 0}},
            {61, new int[] {223, 255, 127}},
            {62, new int[] {124, 165, 0}},
            {63, new int[] {145, 165, 82}},
            {64, new int[] {95, 127, 0}},
            {65, new int[] {111, 127, 63}},
            {66, new int[] {57, 76, 0}},
            {67, new int[] {66, 76, 38}},
            {68, new int[] {28, 38, 0}},
            {69, new int[] {33, 38, 19}},
            {70, new int[] {127, 255, 0}},
            {71, new int[] {191, 255, 127}},
            {72, new int[] {82, 165, 0}},
            {73, new int[] {124, 165, 82}},
            {74, new int[] {63, 127, 0}},
            {75, new int[] {95, 127, 63}},
            {76, new int[] {38, 76, 0}},
            {77, new int[] {57, 76, 38}},
            {78, new int[] {19, 38, 0}},
            {79, new int[] {28, 38, 19}},
            {80, new int[] {63, 255, 0}},
            {81, new int[] {159, 255, 127}},
            {82, new int[] {41, 165, 0}},
            {83, new int[] {103, 165, 82}},
            {84, new int[] {31, 127, 0}},
            {85, new int[] {79, 127, 63}},
            {86, new int[] {19, 76, 0}},
            {87, new int[] {47, 76, 38}},
            {88, new int[] {9, 38, 0}},
            {89, new int[] {23, 38, 19}},
            {90, new int[] {0, 255, 0}},
            {91, new int[] {125, 255, 127}},
            {92, new int[] {0, 165, 0}},
            {93, new int[] {82, 165, 82}},
            {94, new int[] {0, 127, 0}},
            {95, new int[] {63, 127, 63}},
            {96, new int[] {0, 76, 0}},
            {97, new int[] {38, 76, 38}},
            {98, new int[] {0, 38, 0}},
            {99, new int[] {19, 38, 19}},
            {100, new int[] {0, 255, 63}},
            {101, new int[] {127, 255, 159}},
            {102, new int[] {0, 165, 41}},
            {103, new int[] {82, 165, 103}},
            {104, new int[] {0, 127, 31}},
            {105, new int[] {63, 127, 79}},
            {106, new int[] {0, 76, 19}},
            {107, new int[] {38, 76, 47}},
            {108, new int[] {0, 38, 9}},
            {109, new int[] {19, 88, 23}},
            {110, new int[] {0, 255, 127}},
            {111, new int[] {127, 255, 191}},
            {112, new int[] {0, 165, 82}},
            {113, new int[] {82, 165, 124}},
            {114, new int[] {0, 127, 63}},
            {115, new int[] {63, 127, 95}},
            {116, new int[] {0, 76, 38}},
            {117, new int[] {38, 76, 57}},
            {118, new int[] {0, 38, 19}},
            {119, new int[] {19, 88, 28}},
            {120, new int[] {0, 255, 191}},
            {121, new int[] {127, 255, 223}},
            {122, new int[] {0, 165, 124}},
            {123, new int[] {82, 165, 145}},
            {124, new int[] {0, 127, 95}},
            {125, new int[] {63, 127, 111}},
            {126, new int[] {0, 76, 57}},
            {127, new int[] {38, 76, 66}},
            {128, new int[] {0, 38, 28}},
            {129, new int[] {19, 88, 88}},
            {130, new int[] {0, 255, 255}},
            {131, new int[] {127, 255, 255}},
            {132, new int[] {0, 165, 165}},
            {133, new int[] {82, 165, 165}},
            {134, new int[] {0, 127, 127}},
            {135, new int[] {63, 127, 127}},
            {136, new int[] {0, 76, 76}},
            {137, new int[] {38, 76, 76}},
            {138, new int[] {0, 38, 38}},
            {139, new int[] {19, 88, 88}},
            {140, new int[] {0, 191, 255}},
            {141, new int[] {127, 223, 255}},
            {142, new int[] {0, 124, 165}},
            {143, new int[] {82, 145, 165}},
            {144, new int[] {0, 95, 127}},
            {145, new int[] {63, 111, 217}},
            {146, new int[] {0, 57, 76}},
            {147, new int[] {38, 66, 126}},
            {148, new int[] {0, 28, 38}},
            {149, new int[] {19, 88, 88}},
            {150, new int[] {0, 127, 255}},
            {151, new int[] {127, 191, 255}},
            {152, new int[] {0, 82, 165}},
            {153, new int[] {82, 124, 165}},
            {154, new int[] {0, 63, 127}},
            {155, new int[] {63, 95, 127}},
            {156, new int[] {0, 38, 76}},
            {157, new int[] {38, 57, 126}},
            {158, new int[] {0, 19, 38}},
            {159, new int[] {19, 28, 88}},
            {160, new int[] {0, 63, 255}},
            {161, new int[] {127, 159, 255}},
            {162, new int[] {0, 41, 165}},
            {163, new int[] {82, 103, 165}},
            {164, new int[] {0, 31, 127}},
            {165, new int[] {63, 79, 127}},
            {166, new int[] {0, 19, 76}},
            {167, new int[] {38, 47, 126}},
            {168, new int[] {0, 9, 38}},
            {169, new int[] {19, 23, 88}},
            {170, new int[] {0, 0, 255}},
            {171, new int[] {127, 127, 255}},
            {172, new int[] {0, 0, 165}},
            {173, new int[] {82, 82, 165}},
            {174, new int[] {0, 0, 127}},
            {175, new int[] {63, 63, 127}},
            {176, new int[] {0, 0, 76}},
            {177, new int[] {38, 38, 126}},
            {178, new int[] {0, 0, 38}},
            {179, new int[] {19, 19, 88}},
            {180, new int[] {63, 0, 255}},
            {181, new int[] {159, 127, 255}},
            {182, new int[] {41, 0, 165}},
            {183, new int[] {103, 82, 165}},
            {184, new int[] {31, 0, 127}},
            {185, new int[] {79, 63, 127}},
            {186, new int[] {19, 0, 76}},
            {187, new int[] {47, 38, 126}},
            {188, new int[] {9, 0, 38}},
            {189, new int[] {23, 19, 88}},
            {190, new int[] {127, 0, 255}},
            {191, new int[] {191, 127, 255}},
            {192, new int[] {165, 0, 82}},
            {193, new int[] {124, 82, 165}},
            {194, new int[] {63, 0, 127}},
            {195, new int[] {95, 63, 127}},
            {196, new int[] {38, 0, 76}},
            {197, new int[] {57, 38, 126}},
            {198, new int[] {19, 0, 38}},
            {199, new int[] {28, 19, 88}},
            {200, new int[] {191, 0, 255}},
            {201, new int[] {223, 127, 255}},
            {202, new int[] {124, 0, 165}},
            {203, new int[] {142, 82, 165}},
            {204, new int[] {95, 0, 127}},
            {205, new int[] {111, 63, 127}},
            {206, new int[] {57, 0, 76}},
            {207, new int[] {66, 38, 76}},
            {208, new int[] {28, 0, 38}},
            {209, new int[] {88, 19, 88}},
            {210, new int[] {255, 0, 255}},
            {211, new int[] {255, 127, 255}},
            {212, new int[] {165, 0, 165}},
            {213, new int[] {165, 82, 165}},
            {214, new int[] {127, 0, 127}},
            {215, new int[] {127, 63, 127}},
            {216, new int[] {76, 0, 76}},
            {217, new int[] {76, 38, 76}},
            {218, new int[] {38, 0, 38}},
            {219, new int[] {88, 19, 88}},
            {220, new int[] {255, 0, 191}},
            {221, new int[] {255, 127, 223}},
            {222, new int[] {165, 0, 124}},
            {223, new int[] {165, 82, 145}},
            {224, new int[] {127, 0, 95}},
            {225, new int[] {127, 63, 111}},
            {226, new int[] {76, 0, 57}},
            {227, new int[] {76, 38, 66}},
            {228, new int[] {38, 0, 28}},
            {229, new int[] {88, 19, 88}},
            {230, new int[] {255, 0, 127}},
            {231, new int[] {255, 127, 191}},
            {232, new int[] {165, 0, 82}},
            {233, new int[] {165, 82, 124}},
            {234, new int[] {127, 0, 63}},
            {235, new int[] {127, 63, 95}},
            {236, new int[] {76, 0, 38}},
            {237, new int[] {76, 38, 57}},
            {238, new int[] {38, 0, 19}},
            {239, new int[] {88, 19, 28}},
            {240, new int[] {255, 0, 63}},
            {241, new int[] {255, 127, 159}},
            {242, new int[] {165, 0, 41}},
            {243, new int[] {165, 82, 103}},
            {244, new int[] {127, 0, 31}},
            {245, new int[] {127, 63, 79}},
            {246, new int[] {76, 0, 19}},
            {247, new int[] {76, 38, 47}},
            {248, new int[] {38, 0, 9}},
            {249, new int[] {88, 19, 23}},
            {250, new int[] {0, 0, 0}},
            {251, new int[] {101, 101, 101}},
            {252, new int[] {102, 102, 102}},
            {253, new int[] {153, 153, 153}},
            {254, new int[] {204, 204, 204}},
            {255, new int[] {255, 255, 255}}
        };

        private const int indexByLayer = 256;
        private const int indexByBlock = 0;

        public int Index { get; set; }

        public AciColor(int index)
        {
            if (index < 0 || index > 256)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "index must be between 0 and 256");
            }

            Index = index;
        }

        public bool IsByLayer => Index == indexByLayer;

        public bool IsByBlock => Index == indexByBlock;

        public Color GetColor()
        {
            if (Index == 0 || Index == 256)
            {
                return Color.Empty;
            }

            var aci = AciColors[Index];
            return Color.FromArgb(aci[0], aci[1], aci[2]);
        }
    }
}

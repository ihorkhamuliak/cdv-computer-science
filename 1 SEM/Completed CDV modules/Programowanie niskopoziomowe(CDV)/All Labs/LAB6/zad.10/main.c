#include <stdio.h>
#include "macros.h"

int main()
{
    int a, b;

    printf("Podaj dwie liczby calkowite: ");
    scanf("%d %d", &a, &b);

    printf("Suma:      %d\n", SUM(a, b));
    printf("Roznica:   %d\n", DIFF(a, b));
    printf("Iloczyn:   %d\n", MUL(a, b));
    printf("Kwadrat a: %d\n", SQUARE(a));
    printf("Kwadrat b: %d\n", SQUARE(b));

#ifdef DEBUG
    printf("\n[DEBUG] a = %d, b = %d\n", a, b);
    printf("[DEBUG] SQUARE(a+b) = %d\n", SQUARE(a + b));
#endif

    return 0;
}
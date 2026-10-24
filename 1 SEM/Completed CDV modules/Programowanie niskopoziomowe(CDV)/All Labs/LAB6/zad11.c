#include <stdio.h>

#define TEST  

#ifdef _WIN32
    #define PLATFORM_NAME "Windows"
#elif defined(__linux__)
    #define PLATFORM_NAME "Linux"
#else
    #define PLATFORM_NAME "Nieznana"
#endif

int main()
{
    printf("Program uruchomiony na: %s\n", PLATFORM_NAME);

#ifdef TEST
    printf("Tryb testowy wlaczony\n");
#endif

    return 0;
}
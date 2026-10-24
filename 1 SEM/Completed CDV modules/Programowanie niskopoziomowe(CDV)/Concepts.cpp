#include <stdlib.h>
#include <stdio.h>

int main() {
    // 1.Memory leak
    int *wyciek = (int*)malloc(sizeof(int)); 
    wyciek = NULL; // Tracimy adres

    // ----------------------------------------------------

    int *p = (int*)malloc(sizeof(int));
    *p = 100;
    
    free(p); // Zwalniamy pamięć prawidłowo. 
    // 2. DANGLING POINTER .

    // 3. USE-AFTER-FREE 
    *p = 50; 
    // 4. DOUBLE FREE 
    free(p); 

    return 0;
}
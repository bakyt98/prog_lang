#include <iostream>

using namespace std;

int a[100];
int n,k;

void print() {
	for (int i = 0; i < n; i ++) {
		if (a[i] < 10) cout << a[i];
		else cout << (char)(a[i] + 'a' - 10);
	}
	cout << "\n";
}

void rec(int x) {
	if (x >= n) {
		print();
		return;
	}
	for (a[x]=0; a[x]<=k; a[x]++){
	    rec(x+1); }
}

int main() {
	cin >> n>>k;
	rec(0);
}
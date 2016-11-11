
#include <iostream>
using namespace std;

int a[100];
int n;

void print(){
int b[100];
	for (int i = 1; i <= n; ++i)
		b[i] = 0;
	for (int i=0; i<n; i++){
		if (b[a[i]]!=0)
			return;
		b[a[i]] = true;
	}
	for (int i = 0; i < n; ++i)
		cout << a[i];
	cout << endl;
}

void arrange(int x) {
	if (x>=n){
		print();
		return;
	}
	for (int i=1; i<=n; i++){
		a[x]=i;
		arrange(x+1);
	}
}

int main() {
	cin>>n;
	arrange(0);
	return 0;
}

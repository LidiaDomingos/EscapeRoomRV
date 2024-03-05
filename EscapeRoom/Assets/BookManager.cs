using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BookManager : MonoBehaviour
{
    public int books;
    public int final = 3;
    public UnityEvent showKey;

    public void UpdateBooks() {
        books = books + 1;
        if (books == final){
            showKey.Invoke();
        }
    }
}

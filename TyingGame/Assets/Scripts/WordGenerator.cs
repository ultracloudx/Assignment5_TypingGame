using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = { "algorithm", "argument", "arrays", "arithmetic", "assignment", "augmented", "autonomous", "binary", "bit", 
                                        "coding", "computer", "conditional", "loop", "function", "machine", "neural", "python", "java", "javascript",
                                        "script", "sprite", "statement", "variable", "phishing", "malware", "ransomware", "spoofing", "encryption",
                                        "adware", "https", "bot", "botnet", "ddos", "firewall", "payload", "rootkit", "spam", "worm", "cloaking", 
                                        "mainframe", "hack", "hacking", "backdoor", "bug", "cracking", "crypto", "exploit", "hashing", "jailbreak", "keys", 
                                        "metadata", "plaintext", "salting", "hashing", "spyware", "token", "verification", "vpn", "virus", "float", "string",
                                        "integer", "serializable", "public", "private", "boolean"};

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        return randomWord;
    }
}

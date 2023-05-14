using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TextSpawn : MonoBehaviour
{
    private string pinyin;
    private WordFeed wordFeed;
    private string word;
    private string wordFeedEntry;

    public string GetPinyin()
    {
        return pinyin;
    }

    void Start()
    {
        wordFeed = GameObject.Find("WordFeed").GetComponent<WordFeed>();
    }

    // Update is called once per frame
    void Update()
    {
        // if text falls out of bounds, play fart sound and respawn
        if (transform.position.y < -10)
            WordFail();
    }

    public void WordMatch()
    {
        Explode();
        wordFeedEntry = pinyin + ',' + word + ',' + "Y";
        wordFeed.AddWord(wordFeedEntry);
        Respawn();
    }

    public void WordFail()
    {
        AudioSource au = GameObject.Find("Fart").GetComponent<AudioSource>();
        au.Play();
        wordFeedEntry = pinyin + ',' + word + ',' + "N";
        wordFeed.AddWord(wordFeedEntry);
        Respawn();
    }

    // Explosion at location of the current text object
    private void Explode() {
        GameObject explosion = GameObject.Find("Explosion");
        explosion.transform.position = this.transform.position;
        ParticleSystem exp = explosion.GetComponent<ParticleSystem>();
        AudioSource au = explosion.GetComponent<AudioSource>();
        // play explosion particle system
        exp.Play();
        // play sound
        au.Play();
    }

    private void Respawn()
    {
        float randomX = UnityEngine.Random.Range(-5, 5);
        float randomY = UnityEngine.Random.Range(5, 20);
        float randomZ = UnityEngine.Random.Range(-5, 5);

        // Respawn text at random location, within constraints
        transform.position = new Vector3(randomX, randomY, randomZ);

        // reset velocity at respawn
        var rigidbody = GetComponent<Rigidbody>();
        float randomXVel = UnityEngine.Random.Range(-1, 1);
        float randomYVel = UnityEngine.Random.Range(0, -4);
        float randomZVel = UnityEngine.Random.Range(-1, 1);
        rigidbody.velocity = new Vector3(randomXVel, randomYVel, randomZVel);

        // set text to random word from word list
        WordFileReader reader = GameObject.Find("WordFileReader").GetComponent<WordFileReader>();
        int randomWordIndex = UnityEngine.Random.Range(0, reader.words.Length);

        this.word = reader.words[randomWordIndex];
        GetComponent<TextMesh>().text = word;

        // associate word with its pinyin for this text object
        pinyin = reader.wordPairs[word];
    }
}

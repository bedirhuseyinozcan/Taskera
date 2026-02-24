"use client";

import styles from "./about.module.css";
import React, { useState } from "react";
import Image from "next/image";

export default function AboutPage() {
    const [zoomedImg, setZoomedImg] = useState<string | null>(null);

    return (
        <div className={styles.container}>
            <header className={styles.header}>
                <h1 className={styles.title}>Biz Kimiz & İletişim</h1>
                <p className={styles.subtitle}>
                    Herhangi bir konuda bize ulaşmak için aşağıdaki iletişim bilgilerini kullanabilirsiniz.
                </p>
            </header>

            <div className={styles.content}>
                <div className={styles.card}>
                    <div className={styles.profileSection}>
                        <div className={styles.imagePlaceholder}>
                            <Image
                                src="/img/bedir.png"
                                alt="Bedir Özcan"
                                width={140}
                                height={140}
                                className={styles.profileImage}
                                onClick={() => setZoomedImg("/img/bedir.png")}
                            />
                        </div>
                        <h2 className={styles.name}>Bedir Özcan</h2>
                        <p className={styles.role}>Full-Stack Developer</p>
                    </div>

                    <div className={styles.contactDetails}>
                        <a href="#" className={styles.contactItem} target="_blank" rel="noopener noreferrer">
                            <span className={styles.icon}>🔗</span>
                            <span>LinkedIn</span>
                        </a>
                        <a href="#" className={styles.contactItem} target="_blank" rel="noopener noreferrer">
                            <span className={styles.icon}>💻</span>
                            <span>GitHub</span>
                        </a>
                        <a href="#" className={styles.contactItem}>
                            <span className={styles.icon}>✉️</span>
                            <span>bedirhozcan@gmail.com</span>
                        </a>
                    </div>
                </div>

                <div className={styles.card}>
                    <div className={styles.profileSection}>
                        <div className={styles.imagePlaceholder}>
                            <Image
                                src="/img/yunus.jpg"
                                alt="Yunus Emre Ekinci"
                                fill
                                className={styles.profileImage}
                                onClick={() => setZoomedImg("/img/yunus.jpg")}
                            />
                        </div>
                        <h2 className={styles.name}>Yunus Emre Ekinci</h2>
                        <p className={styles.role}>ASP.NET & Backend Geliştirici</p>
                    </div>

                    <div className={styles.contactDetails}>
                        <a href="#" className={styles.contactItem} target="_blank" rel="noopener noreferrer">
                            <span className={styles.icon}>🔗</span>
                            <span>LinkedIn</span>
                        </a>
                        <a href="#" className={styles.contactItem} target="_blank" rel="noopener noreferrer">
                            <span className={styles.icon}>💻</span>
                            <span>GitHub</span>
                        </a>
                        <a href="#" className={styles.contactItem}>
                            <span className={styles.icon}>✉️</span>
                            <span>emrekinci1508@gmail.com</span>
                        </a>
                    </div>
                </div>
            </div>

            {zoomedImg && (
                <div className={styles.zoomOverlay} onClick={() => setZoomedImg(null)}>
                    <Image
                        src={zoomedImg}
                        alt="Büyük Profil Fotoğrafı"
                        width={400}
                        height={400}
                        className={styles.zoomedImage}
                    />
                </div>
            )}
        </div>
    );
}

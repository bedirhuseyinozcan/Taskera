"use client";

import styles from "./page.module.css";
import BoardCard from "@/components/BoardCard";
import { useState } from "react";
import React from "react";

const MOCK_BOARDS = [
  { id: "1", title: "Taskera Projesi", description: "Frontend geliştirme süreci ve tasarım adımları.", lastActive: "2 saat önce" },
  { id: "2", title: "Pazarlama Kampanyası", description: "Q3 Sosyal Medya ve Reklam stratejileri", lastActive: "1 gün önce" },
  { id: "3", title: "Kişisel Hedefler", description: "2026 yılı okuma listesi ve spor programı", lastActive: "3 gün önce" },
];

export default function Home() {
  const [boards] = useState(MOCK_BOARDS);

  const handleCreateBoard = () => {
    alert("Yeni Pano Oluştur modülü yakında aktif olacak.");
  };

  return (
    <div className={styles.container}>
      <header className={styles.header}>
        <h1 className={styles.title}>Panolarım</h1>
      </header>

      <section className={styles.section}>
        <h2 className={styles.sectionTitle}>
          <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round" style={{ color: "var(--primary)" }}>
            <rect x="3" y="3" width="7" height="7"></rect>
            <rect x="14" y="3" width="7" height="7"></rect>
            <rect x="14" y="14" width="7" height="7"></rect>
            <rect x="3" y="14" width="7" height="7"></rect>
          </svg>
          Çalışma Alanları
        </h2>

        <div className={styles.grid}>
          {boards.map((board) => (
            <BoardCard
              key={board.id}
              id={board.id}
              title={board.title}
              description={board.description}
              lastActive={board.lastActive}
            />
          ))}

          <BoardCard
            id="create-new"
            title="Yeni Pano Oluştur"
            isCreate={true}
            onClick={handleCreateBoard}
          />
        </div>
      </section>
    </div>
  );
}

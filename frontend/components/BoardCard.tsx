"use client";

import Link from "next/link";
import styles from "./BoardCard.module.css";
import React from "react";

interface BoardCardProps {
    id: string;
    title: string;
    description?: string;
    lastActive?: string;
    isCreate?: boolean;
    onClick?: () => void;
}

export default function BoardCard({
    id,
    title,
    description,
    lastActive,
    isCreate = false,
    onClick,
}: BoardCardProps) {
    if (isCreate) {
        return (
            <button className={styles.cardCreate} onClick={onClick}>
                <div className={styles.iconWrapper}>
                    <svg
                        width="24"
                        height="24"
                        viewBox="0 0 24 24"
                        fill="none"
                        stroke="currentColor"
                        strokeWidth="2"
                        strokeLinecap="round"
                        strokeLinejoin="round"
                    >
                        <line x1="12" y1="5" x2="12" y2="19"></line>
                        <line x1="5" y1="12" x2="19" y2="12"></line>
                    </svg>
                </div>
                <span className={styles.createText}>{title}</span>
            </button>
        );
    }

    return (
        <Link href={`/board/${id}`} className={styles.card}>
            <div>
                <h3 className={styles.title}>{title}</h3>
                {description && <p className={styles.description}>{description}</p>}
            </div>
            {lastActive && (
                <div className={styles.footer}>
                    <span>Son aktivite:</span>
                    <span>{lastActive}</span>
                </div>
            )}
        </Link>
    );
}

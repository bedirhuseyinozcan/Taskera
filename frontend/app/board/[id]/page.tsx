"use client";

import React, { useState, use } from "react";
import styles from "./board.module.css";

// Types
interface Task {
    id: string;
    title: string;
    labelColor?: string;
    comments?: number;
    attachments?: number;
}

interface Column {
    id: string;
    title: string;
    tasks: Task[];
}


const initialColumns: Column[] = [
    {
        id: "col-1",
        title: "Yapılacaklar (To Do)",
        tasks: [
            { id: "task-1", title: "Proje gereksinim analizini tamamla", labelColor: "#ef4444", comments: 3 },
            { id: "task-2", title: "Veritabanı şemasını tasarla", attachments: 2 },
            { id: "task-3", title: "API uç noktalarını belirle", labelColor: "#eab308" },
        ],
    },
    {
        id: "col-2",
        title: "Yapılıyor (Doing)",
        tasks: [
            { id: "task-4", title: "Next.js arayüz tasarımlarını (Frontend) kodla", labelColor: "#3b82f6", comments: 1, attachments: 1 },
            { id: "task-5", title: "Kimlik doğrulama sistemini (Auth) entegre et" },
        ],
    },
    {
        id: "col-3",
        title: "Yapıldı (Done)",
        tasks: [
            { id: "task-6", title: "Proje klasör yapısını kur", labelColor: "#22c55e" },
        ],
    },
];

export default function BoardPage({ params }: { params: Promise<{ id: string }> }) {
    
    const resolvedParams = use(params);
    const [columns, setColumns] = useState<Column[]>(initialColumns);
    const [newColumnTitle, setNewColumnTitle] = useState("");
    const [isAddingColumn, setIsAddingColumn] = useState(false);

    
    const [addingTaskToColId, setAddingTaskToColId] = useState<string | null>(null);
    const [newTaskTitle, setNewTaskTitle] = useState("");

    const handleAddColumn = () => {
        if (!newColumnTitle.trim()) {
            setIsAddingColumn(false);
            return;
        }

        const newCol: Column = {
            id: `col-${Date.now()}`,
            title: newColumnTitle,
            tasks: [],
        };

        setColumns([...columns, newCol]);
        setNewColumnTitle("");
        setIsAddingColumn(false);
    };

    const handleAddTask = (columnId: string) => {
        if (!newTaskTitle.trim()) {
            setAddingTaskToColId(null);
            return;
        }

        const updatedColumns = columns.map((col) => {
            if (col.id === columnId) {
                return {
                    ...col,
                    tasks: [
                        ...col.tasks,
                        { id: `task-${Date.now()}`, title: newTaskTitle },
                    ],
                };
            }
            return col;
        });

        setColumns(updatedColumns);
        setNewTaskTitle("");
        setAddingTaskToColId(null);
    };

    return (
        <div className={styles.boardContainer}>
            <div className={styles.boardHeader}>
                <h1 className={styles.boardTitle}>Taskera Projesi (Pano #{resolvedParams.id})</h1>
                <div className={styles.boardActions}>
                    <button className={styles.secondaryBtn}>
                        <svg width="16" height="16" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
                        </svg>
                        Davet Et
                    </button>
                    <button className={styles.primaryBtn}>
                        <svg width="16" height="16" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M5 12h14M12 5l7 7-7 7" />
                        </svg>
                        Paylaş
                    </button>
                </div>
            </div>

            <div className={styles.columnsWrapper}>
                {columns.map((column) => (
                    <div key={column.id} className={styles.column}>
                        <div className={styles.columnHeader}>
                            <h2 className={styles.columnTitle}>{column.title}</h2>
                            <span className={styles.taskCount}>{column.tasks.length}</span>
                        </div>

                        <div className={styles.cardsContainer}>
                            {column.tasks.map((task) => (
                                <div key={task.id} className={styles.card}>
                                    {task.labelColor && (
                                        <div className={styles.cardLabels}>
                                            <span className={styles.label} style={{ backgroundColor: task.labelColor }}></span>
                                        </div>
                                    )}
                                    <h3 className={styles.cardTitle}>{task.title}</h3>
                                    {(task.comments || task.attachments) && (
                                        <div className={styles.cardFooter}>
                                            <div className={styles.cardIcons}>
                                                {task.comments && (
                                                    <div className={styles.iconWithText}>
                                                        <svg width="14" height="14" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M8 12h.01M12 12h.01M16 12h.01M21 12c0 4.418-4.03 8-9 8a9.863 9.863 0 01-4.255-.949L3 20l1.395-3.72C3.512 15.042 3 13.574 3 12c0-4.418 4.03-8 9-8s9 3.582 9 8z" />
                                                        </svg>
                                                        <span>{task.comments}</span>
                                                    </div>
                                                )}
                                                {task.attachments && (
                                                    <div className={styles.iconWithText}>
                                                        <svg width="14" height="14" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M15.172 7l-6.586 6.586a2 2 0 102.828 2.828l6.414-6.586a4 4 0 00-5.656-5.656l-6.415 6.585a6 6 0 108.486 8.486L20.5 13" />
                                                        </svg>
                                                        <span>{task.attachments}</span>
                                                    </div>
                                                )}
                                            </div>
                                            <div className={styles.avatar}>T</div>
                                        </div>
                                    )}
                                </div>
                            ))}

                            
                            {addingTaskToColId === column.id && (
                                <div className={styles.addInputContainer}>
                                    <textarea
                                        className={styles.autoResizeTextarea}
                                        placeholder="Bu kart için bir başlık girin..."
                                        value={newTaskTitle}
                                        onChange={(e) => setNewTaskTitle(e.target.value)}
                                        autoFocus
                                        onKeyDown={(e) => {
                                            if (e.key === "Enter" && !e.shiftKey) {
                                                e.preventDefault();
                                                handleAddTask(column.id);
                                            }
                                        }}
                                    />
                                    <div className={styles.addInputActions}>
                                        <button className={styles.primaryBtn} onClick={() => handleAddTask(column.id)}>
                                            Kart Ekle
                                        </button>
                                        <button
                                            className={styles.secondaryBtn}
                                            style={{ padding: "0.5rem" }}
                                            onClick={() => {
                                                setAddingTaskToColId(null);
                                                setNewTaskTitle("");
                                            }}
                                        >
                                            <svg width="16" height="16" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12" />
                                            </svg>
                                        </button>
                                    </div>
                                </div>
                            )}
                        </div>

                        
                        {addingTaskToColId !== column.id && (
                            <div className={styles.columnFooter}>
                                <button
                                    className={styles.addCardBtn}
                                    onClick={() => setAddingTaskToColId(column.id)}
                                >
                                    <svg width="16" height="16" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4" />
                                    </svg>
                                    Kart Ekle
                                </button>
                            </div>
                        )}
                    </div>
                ))}

                
                {isAddingColumn ? (
                    <div className={styles.column} style={{ minWidth: "320px", height: "fit-content" }}>
                        <div className={styles.addInputContainer} style={{ padding: "1rem" }}>
                            <input
                                type="text"
                                className={styles.autoResizeTextarea}
                                style={{ minHeight: "40px" }}
                                placeholder="Liste başlığı girin..."
                                value={newColumnTitle}
                                onChange={(e) => setNewColumnTitle(e.target.value)}
                                autoFocus
                                onKeyDown={(e) => {
                                    if (e.key === "Enter") handleAddColumn();
                                }}
                            />
                            <div className={styles.addInputActions} style={{ marginTop: "0.5rem" }}>
                                <button className={styles.primaryBtn} onClick={handleAddColumn}>
                                    Liste Ekle
                                </button>
                                <button
                                    className={styles.secondaryBtn}
                                    style={{ padding: "0.5rem" }}
                                    onClick={() => {
                                        setIsAddingColumn(false);
                                        setNewColumnTitle("");
                                    }}
                                >
                                    <svg width="16" height="16" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                        <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M6 18L18 6M6 6l12 12" />
                                    </svg>
                                </button>
                            </div>
                        </div>
                    </div>
                ) : (
                    <button className={styles.addColumnBtn} onClick={() => setIsAddingColumn(true)}>
                        <svg width="20" height="20" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M12 4v16m8-8H4" />
                        </svg>
                        Başka liste ekle
                    </button>
                )}
            </div>
        </div>
    );
}

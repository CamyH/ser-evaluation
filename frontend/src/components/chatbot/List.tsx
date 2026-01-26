import type { ReactNode } from 'react'

type ListPropType<T> = {
    items: T[]
    renderItem: (item: T, index: number) => ReactNode
    className?: string
}

export const List = <T,>({ items, renderItem, className }: ListPropType<T>) => {
    return <li className={className}>{items.map(renderItem)}</li>
}
